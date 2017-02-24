using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOnCollide : MonoBehaviour {

	public string tagToCollideWith = string.Empty;

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (!otherCollider.CompareTag (tagToCollideWith)) {
			return;
		}
		Destroy (gameObject);
	}
}
