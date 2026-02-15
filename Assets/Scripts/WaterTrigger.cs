using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(MyTags.PLAYER_TAG)) {
			PlayerDamage playerDamage = other.GetComponent<PlayerDamage>();
			if (playerDamage != null) {
				playerDamage.DealDamage();
			}
		}
	}
}
