using Unity.VisualScripting;
using UnityEngine;

public class GetDoubleJump : MonoBehaviour
{
    public Player pr;
    private bool isPlayerInRange;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            anim.SetBool("ifGot", true);
            GetComponent<Collider2D>().enabled = false;
            pr.jumpAbility = 2;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
