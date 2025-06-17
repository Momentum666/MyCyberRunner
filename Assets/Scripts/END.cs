using UnityEngine;
using DialogueEditor;
public class END : MonoBehaviour
{
    private bool isPlayerInRange = false;
    public NPCConversation end;
    private bool hasPlayed = false;
    void Update()
    {
        if (isPlayerInRange&&!hasPlayed)
        {
            ConversationManager.Instance.StartConversation(end);
            hasPlayed = true;
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
