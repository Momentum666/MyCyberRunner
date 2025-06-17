using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("空格键被按下，尝试加载 Level0-1");
            SceneManager.LoadScene("Level0-1", LoadSceneMode.Single);
        }
    }

    public void StartGame()
    {
        Debug.Log("按钮点击：尝试加载 Level0-1");

        if (Application.CanStreamedLevelBeLoaded("Level0-1"))
        {
            Debug.Log("Level0-1 可加载，开始 LoadScene(Single)");
            SceneManager.LoadScene("Level0-1", LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError(" Level0-1 场景未包含在构建中");
        }
    }

}
