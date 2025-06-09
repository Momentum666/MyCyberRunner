using DialogueEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class PlayerTest : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float xInput;
    [Header("Movement")]
    private float currentSpeed;
    private float deltaSpeed;
    [SerializeField] private float accelityFrame;
    [SerializeField] private float jumpforce;
    [SerializeField] private float movespeed;
    public int jumpAbility;
    [SerializeField] private int jumpCount;
    private bool facingRight = true;
    private int facingDir = 1;
    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;
    public int dashAbility;
    [SerializeField] private int dashCount;
    private MovingPlatform currentPlatform;
    [Header("Collision info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;
    public bool isGrounded;
    private bool wasGrounded;
    [SerializeField] private LayerMask whatIsPlatform;
    private int groundLayer;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        deltaSpeed = movespeed / accelityFrame;
        groundLayer=whatIsGround|whatIsPlatform;
    }
    void Update()
    {
        if (ConversationManager.Instance.IsConversationActive)
        {
            rb.linearVelocity = new Vector2(0, 0);
            return;
        }
        Xmovement();
        Ymovement();
        CollisionCheck();
        dashTime-= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCount>0 && !isGrounded)
        {
            dashTime = dashDuration;
            Debug.Log("I'm doing dash");
            dashCount -= 1;
        }
        DirController();
        AnimatorController();
    }

    private void CollisionCheck()
    {
        wasGrounded = isGrounded;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;
        if (isGrounded&&!wasGrounded)
            jumpCount = jumpAbility;
        if (hit.collider != null && hit.collider.gameObject.layer==LayerMask.NameToLayer("MovingPlatform"))
            currentPlatform = hit.collider.GetComponent<MovingPlatform>();
        else
            currentPlatform = null;
    }

    private void Xmovement()
    {
        float totalXSpeed = currentSpeed;
        xInput = Input.GetAxisRaw("Horizontal");
        float maxSpeed=xInput*movespeed;
        currentSpeed= Mathf.MoveTowards(currentSpeed, maxSpeed, deltaSpeed);
        if (isGrounded)
            dashCount = dashAbility;
        if (dashTime > 0)
        {
            rb.linearVelocityX = xInput * dashSpeed;
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
        bool isJumping = rb.linearVelocityY > 0;
        if (Input.GetKeyDown(KeyCode.Space)&&jumpCount>0)
        {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpforce);
                jumpCount--;
        }
        if (Input.GetKeyUp(KeyCode.Space)&&isJumping)
            rb.linearVelocity= new Vector2(rb.linearVelocityX, rb.linearVelocityY*0.4f);
    }

    private void AnimatorController()
    {
        bool isMoving = rb.linearVelocityX != 0;
        anim.SetFloat("yVelocity",rb.linearVelocityY);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded",isGrounded);
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void DirController()
    {
        if (rb.linearVelocityX > 0 && !facingRight&& currentPlatform == null)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight&& currentPlatform == null)
            Flip();
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
