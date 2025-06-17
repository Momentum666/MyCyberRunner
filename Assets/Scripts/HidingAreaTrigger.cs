using UnityEngine;

public class HidingAreaTrigger : MonoBehaviour
{
    public GameObject hidingArea;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            hidingArea.SetActive(false);
        }
    }
}
