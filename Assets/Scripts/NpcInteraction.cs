using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;

public class NpcInteraction : MonoBehaviour
{
    public Player player;
    public Animator anim;
    [SerializeField] private NPCConversation FirstTalkWithMiner;
    [SerializeField] private NPCConversation SecondTalkWithMiner;
    [SerializeField] private bool hasPlayed = false;
    public GameObject InteractionPrompt;
    private bool isPlayerInRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = player.GetComponentInChildren<Animator>();
        if (InteractionPrompt != null)
            InteractionPrompt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && !hasPlayed&& player.isGrounded)
        {
            anim.SetBool("isMoving", false);
            ConversationManager.Instance.StartConversation(FirstTalkWithMiner);
            hasPlayed = true;
        }
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)&&player.isGrounded)
            ConversationManager.Instance.StartConversation(SecondTalkWithMiner);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionPrompt.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InteractionPrompt.SetActive(false);
            isPlayerInRange = false;
        }
    }
}