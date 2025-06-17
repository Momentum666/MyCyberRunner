using Unity.VisualScripting;
using UnityEngine;
using DialogueEditor;

public class GetDoubleJump : MonoBehaviour
{
    public Player pr;
    public GameObject Gear1;
    private bool isPlayerInRange;
    private Animator anim;
    [SerializeField] private NPCConversation GetGear1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        if (isPlayerInRange)
        {
            anim.SetBool("ifGot", true);
            pr.jumpAbility = 2;
            pr.jumpCount = 2;
            ConversationManager.Instance.StartConversation(GetGear1);
            ConversationManager.OnConversationEnded += OnDialogueEnded;
        }
    }
    void OnDialogueEnded()
    {
        ConversationManager.OnConversationEnded -= OnDialogueEnded;
        Gear1.SetActive(false);
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