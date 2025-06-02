using UnityEngine;
using DialogueEditor;
using UnityEditor;
using UnityEngine.Playables;

public class ShowLeg : MonoBehaviour
{
    public Player player;
    private PlayableDirector dr;
    public Animator anim;
    [SerializeField] NPCConversation FirstTimeArrivedIndustrialZone;
    [SerializeField] NPCConversation FoundLeg;
    private bool isPlayerInRange = false;
    private bool hasPlayed = false;
    private bool hasFoundLeg=false;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        dr=GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && !hasPlayed&&player.isGrounded)
        {
            anim.SetBool("isMoving", false);
            ConversationManager.Instance.StartConversation(FirstTimeArrivedIndustrialZone);
            hasPlayed = true;
            ConversationManager.OnConversationEnded += OnDialogueEnded;
        }

    }
    void OnDialogueEnded()
    {
        ConversationManager.OnConversationEnded -= OnDialogueEnded;
        dr.Play();
        dr.stopped += PlayFoundLeg;
    }

    void PlayFoundLeg(PlayableDirector dr)
    {
        if (!hasFoundLeg)
        {
            hasFoundLeg = true;
            ConversationManager.Instance.StartConversation(FoundLeg);
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
