using UnityEngine;

public class TutorialHoldSpace : MonoBehaviour
{
    public GameObject promptHoldSpace;
    void Start()
    {
        promptHoldSpace.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            promptHoldSpace.SetActive(true);
        }
    }

}