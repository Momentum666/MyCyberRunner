using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;

public class NpcInteraction : MonoBehaviour
{
    [SerializeField] private NPCConversation FirstTalkWithMiner;
    [SerializeField] private NPCConversation SecondTalkWithMiner;
    [SerializeField] private bool hasPlayed = false;
    public GameObject interactionPrompt;
    private bool isPlayerInRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && !hasPlayed)
        {
            ConversationManager.Instance.StartConversation(FirstTalkWithMiner);
            hasPlayed = true;
        }
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
            ConversationManager.Instance.StartConversation(SecondTalkWithMiner);
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