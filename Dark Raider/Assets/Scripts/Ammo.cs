using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

	public float damage = 100.0f;
	public float lifetime = 1.0f;

	// Use this for initialization
	void Start () {
		Invoke ("Die", lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (!otherCollider.CompareTag ("Player")) {
			return;
		}
		PlayerController.Health -= damage;
	}

	public void Die() {
		Destroy (gameObject);
	}
}
