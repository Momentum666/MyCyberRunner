using UnityEngine;

public class JumpPlus : MonoBehaviour
{
    private bool isGot = false;
    public Player player;
    private PlayerRespawn respawn;
    [SerializeField] private GameObject item;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        respawn = player.GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGot && item.name == "Red Jump++")
        {
            player.jumpCount++;
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
