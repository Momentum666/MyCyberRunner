using DialogueEditor;
using UnityEngine;

public class TutorialExchangeAbility : MonoBehaviour
{
    private bool playerInRange = false;
    private bool hasPlayed = false;
    [SerializeField] private NPCConversation TutorialAbilityExchange;
    void Update()
    {
        if (playerInRange&&!hasPlayed)
        {
            ConversationManager.Instance.StartConversation(TutorialAbilityExchange);
            hasPlayed = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
}
