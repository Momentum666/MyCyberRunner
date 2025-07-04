using UnityEngine;

public class TutorialJump : MonoBehaviour
{
    public GameObject promptJump;
    void Start()
    {
        promptJump.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptJump.SetActive(true);
        }
    }

}