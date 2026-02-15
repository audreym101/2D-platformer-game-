using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : MonoBehaviour {

	public void ReplayGame() {
		if (GameManager.instance != null) {
			GameManager.instance.RestartGame();
		} else {
			SceneManager.LoadScene("Gameplay");
		}
	}

	public void QuitGame() {
		if (GameManager.instance != null) {
			GameManager.instance.QuitGame();
		} else {
			Application.Quit();
		}
	}
}
