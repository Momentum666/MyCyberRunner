using UnityEngine;
using DialogueEditor;

public class GetDash : MonoBehaviour
{
    public Player pr;
    public GameObject Gear2;
    private bool isPlayerInRange;
    private Animator anim;
    [SerializeField] private NPCConversation GetGear2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            anim.SetBool("ifGot", true);
            pr.dashAbility=1;
            ConversationManager.Instance.StartConversation(GetGear2);
            ConversationManager.OnConversationEnded += OnDialogueEnded;
        }
    }
    void OnDialogueEnded()
    {
        ConversationManager.OnConversationEnded -= OnDialogueEnded;
        Gear2.SetActive(false);
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