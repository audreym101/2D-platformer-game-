using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString();
            }
        }
        else
        {
            Debug.LogWarning("Timer expired! Loading EndScene");
            SceneManager.LoadScene("EndScene");
        }
    }
}
