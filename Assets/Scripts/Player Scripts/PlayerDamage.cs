using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour {

	private Text lifeText;
	private int lifeScoreCount;

	private bool canDamage;

	void Awake () {
		GameObject lifeTextObj = GameObject.Find("LifeText");
		if (lifeTextObj != null) {
			lifeText = lifeTextObj.GetComponent<Text>();
		}
		lifeScoreCount = 3;
		if (lifeText != null) {
			lifeText.text = "x" + lifeScoreCount;
		}
		canDamage = true;
	}

	void Start() {
		Time.timeScale = 1f;
	}
	
	public void DealDamage(Vector3? waterPosition = null) {
		if (canDamage) {
			
			lifeScoreCount--;

			if (lifeScoreCount >= 0 && lifeText != null) {
				lifeText.text = "x" + lifeScoreCount;
			}

			if (lifeScoreCount == 0) {
				StartCoroutine(LoadEndScene());
			} else if (GameManager.instance != null && waterPosition.HasValue) {
				GameManager.instance.PlayerDied(waterPosition.Value);
			}

			canDamage = false;
			StartCoroutine (WaitForDamage ());
		}
	}

	IEnumerator WaitForDamage() {
		yield return new WaitForSeconds (2f);
		canDamage = true;
	}

	IEnumerator LoadEndScene() {
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("EndScene");
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
		{
			Vector3 waterPosition = collision.transform.position;
			DealDamage(waterPosition);
		
		}
    }


} // class



























