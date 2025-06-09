using Unity.VisualScripting;
using UnityEngine;
using DialogueEditor;

public class GetDoubleJump : MonoBehaviour
{
    public Player pr;
    public GameObject Leg;
    private bool isPlayerInRange;
    private Animator anim;
    [SerializeField] private NPCConversation GetLeg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            anim.SetBool("ifGot", true);
            pr.jumpAbility = 2;
            ConversationManager.Instance.StartConversation(GetLeg);
            ConversationManager.OnConversationEnded += OnDialogueEnded;
        }
    }
    void OnDialogueEnded()
    {
        ConversationManager.OnConversationEnded -= OnDialogueEnded;
        Leg.SetActive(false);
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
