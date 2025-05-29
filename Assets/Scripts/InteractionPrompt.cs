using DialogueEditor;
using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    public GameObject interactionPrompt;
    public GameObject Player;
    [SerializeField] public bool isPlayerInRange = false;
    [SerializeField] private Vector3 respawnPosition;
    private PlayerRespawn pr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pr = Player.GetComponent<PlayerRespawn>();
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
    }
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            pr.respawnPoint=respawnPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPrompt.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPrompt.SetActive(false);
            isPlayerInRange = false;
        }
    }
}
