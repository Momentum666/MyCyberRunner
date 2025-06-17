using UnityEngine;
public class Bouncing : MonoBehaviour
{
    [SerializeField] private float jumpForce; // 弹跳力
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // 应用弹跳力
                anim.SetTrigger("Bouncing"); // 播放弹跳动画
            }
        }
    }
}