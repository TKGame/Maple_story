using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		BossController.facingRight = true;
	}
}
