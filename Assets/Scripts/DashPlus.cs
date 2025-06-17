using UnityEngine;

public class DashPlus : MonoBehaviour
{
    private bool isGot = false;
    public Player player;
    [SerializeField] private GameObject item;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGot && item.name == "Blue Dash++")
        {
            player.dashCount++;
            anim.SetTrigger("ifGot");
            isGot = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isGot)
        {
            isGot = true;
        }
    }
}
