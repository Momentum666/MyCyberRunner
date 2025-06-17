using UnityEngine;
using DialogueEditor;

public class Player : MonoBehaviour
{
    [SerializeField] private NPCConversation BeginningDialogue;
    private Rigidbody2D rb;
    private Animator anim;
    private float xInput;
    [Header("Movement")]
    private float currentSpeed;
    private float deltaSpeed;
    [SerializeField] private float accelityFrame=8f;
    [SerializeField] private float jumpforce;
    [SerializeField] private float movespeed;
    [SerializeField] private float fallMaxSpeed;
    public int jumpAbility;
    public int jumpCount;
    private bool facingRight = true;
    private int facingDir = 1;
    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    private float dashTime=-1f;
    public int dashAbility;
    public int dashCount;
    public MovingPlatform currentPlatform;
    [Header("Collision info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    public bool isGrounded;
    private bool wasGrounded;
    [SerializeField] private LayerMask whatIsPlatform;
    private int groundLayer;
    public bool canMove = true;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        deltaSpeed = movespeed / accelityFrame;
        groundLayer = whatIsGround | whatIsPlatform;
        ConversationManager.Instance.StartConversation(BeginningDialogue);
    }
    void Update()
    {
        if (ConversationManager.Instance.IsConversationActive || !canMove)
        {
            rb.linearVelocityX = 0;
            return;
        }
        Xmovement();
        Ymovement();
        CollisionCheck();
        dashTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCount > 0 && !isGrounded)
        {
            dashTime = dashDuration;
            Debug.Log("I'm doing dash");
            dashCount -= 1;
        }
        DirController();
        AnimatorController();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void CollisionCheck()
    {
        wasGrounded = isGrounded;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;
        if (isGrounded && !wasGrounded)
            jumpCount = jumpAbility;
        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("MovingPlatform"))
            currentPlatform = hit.collider.GetComponent<MovingPlatform>();
        else
            currentPlatform = null;
    }

    private void Xmovement()
    {
        float totalXSpeed = currentSpeed;
        xInput = Input.GetAxisRaw("Horizontal");
        float maxSpeed = xInput * movespeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, deltaSpeed);
        if (isGrounded)
            dashCount = dashAbility;
        if (dashTime > 0)
        {
            rb.linearVelocity = new Vector2(facingDir * dashSpeed,0);
        }
        else
        {
            if (currentPlatform != null)
                totalXSpeed += currentPlatform.passingVelocity.x;
            rb.linearVelocity = new Vector2(totalXSpeed, rb.linearVelocityY);
        }
    }
    private void Ymovement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpforce);
            jumpCount--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && !isGrounded && rb.linearVelocityY >= 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY + jumpforce * 0.85f);
            jumpCount--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && !isGrounded && rb.linearVelocityY < 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpforce);
            jumpCount--;
        }
        if (rb.linearVelocityY < -fallMaxSpeed)
            rb.linearVelocity = new Vector2(rb.linearVelocityX, -fallMaxSpeed);
    }

    private void AnimatorController()
    {
        bool isMoving = rb.linearVelocityX != 0;
        anim.SetFloat("yVelocity",rb.linearVelocityY);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded",isGrounded);
        anim.SetBool("isDashing", dashTime > 0);
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void DirController()
    {
        if (rb.linearVelocityX > 0 && !facingRight && currentPlatform == null)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight&& currentPlatform == null)
            Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }

    public void FreezePlayer()
    {
        canMove = false;
    }

    public void UnfreezePlayer()
    {
        canMove = true;
    }
}
