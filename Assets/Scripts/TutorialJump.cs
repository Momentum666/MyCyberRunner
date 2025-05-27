using UnityEngine;

public class TutorialJump : MonoBehaviour
{
    public GameObject promptJump;
    [SerializeField] public bool isPlayerInRange = false;
    private bool hasRunned = false;
    void Start()
    {
        promptJump.SetActive(false);
    }
    void Update()
    {
        if (isPlayerInRange && !hasRunned && Input.GetKeyDown(KeyCode.Space))
        {
            promptJump.SetActive(false);
            hasRunned = true;
            isPlayerInRange = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasRunned)
        {
            promptJump.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptJump.SetActive(false);
            isPlayerInRange = false;
        }
    }

}