using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("GameScene-ALU");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
