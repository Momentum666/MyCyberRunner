using UnityEngine;

public class TutorialPrompt : MonoBehaviour
{
    public GameObject promptE;
    [SerializeField] public bool isPlayerInRange = false;
    private bool hasRunned = false;
    void Start()
    {
        promptE.SetActive(false);
    }
    void Update()
    {
        if (isPlayerInRange && !hasRunned && Input.GetKeyDown(KeyCode.E))
        {
            promptE.SetActive(false); 
            hasRunned = true;            
            isPlayerInRange = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasRunned)
        {
            promptE.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptE.SetActive(false);
            isPlayerInRange = false;
        }
    }

}
