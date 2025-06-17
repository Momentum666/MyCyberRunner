using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CinemachineCamera fromCamera;
    public CinemachineCamera targetCamera;
    public float transitionDuration;

    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.CompareTag("Player"))
        {
            StartCoroutine(SwitchCamera());
            triggered = true;
        }
    }

    IEnumerator SwitchCamera()
    {
        targetCamera.Priority = 50;
        fromCamera.Priority = 40;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(transitionDuration);
        Time.timeScale = 1f;
        (fromCamera, targetCamera) = (targetCamera, fromCamera);
        triggered = false;
    }
}
