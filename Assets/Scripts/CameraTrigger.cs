using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CinemachineCamera targetCamera;
    public float transitionDuration = 1.5f;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;

        if (other.CompareTag("Player"))
        {
            StartCoroutine(SwitchCamera());
            triggered = true;
        }
    }

    IEnumerator SwitchCamera()
    {
        targetCamera.Priority = 50;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(transitionDuration);
        Time.timeScale = 1f;
    }
}
