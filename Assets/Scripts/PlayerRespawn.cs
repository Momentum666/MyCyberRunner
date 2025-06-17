// PlayerController.cs（挂在 Player 上）
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;
    public Animator anim;
    [Header("Respawn Animation")]
    [SerializeField] private Animation DeadAnimation;
    [SerializeField] private bool isDead = false;
    public bool hasRespawned = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadArea"))
        {
            hasRespawned = true;
            transform.position = respawnPoint;
        }
    }
}