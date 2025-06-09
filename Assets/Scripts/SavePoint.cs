using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite newSprite;
    public GameObject Player;
    [SerializeField] private Vector3 respawnPosition;
    private PlayerRespawn pr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pr = Player.GetComponent<PlayerRespawn>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pr.respawnPoint = respawnPosition;
            sr.sprite = newSprite;
        }
    }
}
