using UnityEngine;
using DialogueEditor;

public class Player : MonoBehaviour
{

    [SerializeField] private NPCConversation BeginningDialogue;
    private Rigidbody2D rb;
    private Animator anim;
    private float xInput;
    [Header("Movement")]
    [SerializeField] private bool inputlocked;
    [SerializeField] private float jumpforce;
    [SerializeField] private float movespeed;
    [SerializeField] private int jumpAbility;
    [SerializeField] private int jumpCount;
    private bool facingRight = true;
    private int facingDir = 1;
    private bool isGrounded;
    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;
    [SerializeField] private int dashAbility;
    [SerializeField] private int dashCount;
    [Header("Collision info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        ConversationManager.Instance.StartConversation(BeginningDialogue);
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
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void Xmovement()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (isGrounded)
            dashCount = dashAbility;
        if (dashTime > 0)
        {
            rb.linearVelocityX = xInput * dashSpeed;
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * movespeed, rb.linearVelocityY);
        }
    }

    private void Ymovement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                jumpCount = jumpAbility;
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpforce);
                jumpCount--;
                Debug.Log("Jump");
            }
            else if(!isGrounded && jumpCount > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpforce);
                jumpCount--;
                Debug.Log("Double Jump");
            }
        }
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
        if (rb.linearVelocityX > 0 && !facingRight)
            Flip();
        else if (rb.linearVelocityX < 0 && facingRight)
            Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
