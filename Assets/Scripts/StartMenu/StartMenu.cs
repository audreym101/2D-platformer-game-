using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene-ALU");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
