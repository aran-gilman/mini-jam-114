using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string gameSceneName;

    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
