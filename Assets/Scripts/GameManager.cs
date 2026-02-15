using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int lives = 3;
	public GameObject player;
	public TextMeshProUGUI livesText;

	private Vector3 lastSafePosition;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	void Start() {
		if (player != null) {
			lastSafePosition = player.transform.position;
		}
		UpdateLivesUI();
	}

	public void PlayerDied(Vector3 deathPosition) {
		lives--;
		UpdateLivesUI();

		if (lives > 0) {
			StartCoroutine(RespawnPlayer());
		} else {
			SceneManager.LoadScene("EndScene");
		}
	}

	IEnumerator RespawnPlayer() {
		yield return new WaitForSeconds(0.5f);
		
		if (player != null) {
			player.transform.position = lastSafePosition;
			player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
		}
	}

	public void UpdateSafePosition(Vector3 newSafePos) {
		lastSafePosition = newSafePos;
	}

	void UpdateLivesUI() {
		if (livesText != null) {
			livesText.text = "Lives: " + lives;
		}
	}

	public void RestartGame() {
		SceneManager.LoadScene("Gameplay");
	}

	public void QuitGame() {
		Application.Quit();
	}
}
