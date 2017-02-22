using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public int levelID = -1;

	void OnTriggerEnter2D(Collider2D otherCollider) {
		if (!otherCollider.CompareTag ("Player")) {
			return;
		}

		Application.LoadLevel (levelID);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
