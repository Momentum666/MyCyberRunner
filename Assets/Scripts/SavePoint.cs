using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class SavePoint : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite newSprite;
    public GameObject Player;
    [SerializeField] private Vector3 respawnPosition;
    private PlayerRespawn pr;
    public CinemachineCamera targetCamera;
    [SerializeField] private float transitionDuration=0.9f;
    public GameObject[] abilitys;
    [SerializeField] private bool cameraConvertNeeded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pr = Player.GetComponent<PlayerRespawn>();
    }

    void Update()
    {
        if (pr.hasRespawned&&pr.respawnPoint==respawnPosition&&cameraConvertNeeded)
        {
            StartCoroutine(SwitchCamera());
        }
        if (pr.hasRespawned)
        {
            foreach (GameObject ability  in abilitys)
            {

                if (ability.GetComponent<DisableAfterAnim>().animOver)
                {
                    Debug.Log("active");
                    ability.SetActive(true);
                    pr.hasRespawned = false;
                }
            }
        }

    }

    IEnumerator SwitchCamera()
    {
        targetCamera.Priority = 50;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(transitionDuration);
        Time.timeScale = 1f;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pr.respawnPoint = respawnPosition;
            sr.sprite = newSprite;
        }
    }
}
