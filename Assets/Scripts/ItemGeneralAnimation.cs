using UnityEngine;

public class ItemGeneral : MonoBehaviour
{
    private Animator anim;
    private bool isPlayerInRange;
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            anim.SetBool("ifGot", true);
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
