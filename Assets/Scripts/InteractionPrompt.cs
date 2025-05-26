using UnityEngine;

public class InteractionPrompt : MonoBehaviour
{
    public GameObject interactionPrompt;
    [SerializeField] public bool isPlayerInRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (interactionPrompt != null)
            interactionPrompt.SetActive(false);
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
