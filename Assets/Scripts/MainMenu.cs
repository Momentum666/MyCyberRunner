using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�ո�������£����Լ��� Level0-1");
            SceneManager.LoadScene("Level0-1", LoadSceneMode.Single);
        }
    }

    public void StartGame()
    {
        Debug.Log("��ť��������Լ��� Level0-1");

        if (Application.CanStreamedLevelBeLoaded("Level0-1"))
        {
            Debug.Log("Level0-1 �ɼ��أ���ʼ LoadScene(Single)");
            SceneManager.LoadScene("Level0-1", LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError(" Level0-1 ����δ�����ڹ�����");
        }
    }

}
