using UnityEngine;

public class DisableAfterAnim : MonoBehaviour
{
    [SerializeField] private GameObject ob;
    public bool animOver=false;
    public void DisableGameObject()
    {

        Debug.Log("Disabling GameObject: " + ob.name);
        ob.SetActive(false);
        animOver = true;
    }

}