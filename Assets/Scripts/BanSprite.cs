using UnityEngine;

public class SpriteDisappearAfterAnim : MonoBehaviour
{
    public void DisableRenderer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}