using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public float maxSpeed = 10.0f;

	private RectTransform theTransform = null;

	void Awake() {
		theTransform = GetComponent<RectTransform> ();
	}

	// Use this for initialization
	void Start () {
		if (PlayerController.player != null) {
			theTransform.sizeDelta = new Vector2 (
				Mathf.Clamp(PlayerController.Health, 0, 100),
				theTransform.sizeDelta.y
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		float healthUpdate = 0.0f;

		if (PlayerController.player != null) {
			healthUpdate = Mathf.MoveTowards (theTransform.rect.width, PlayerController.Health, maxSpeed);
			theTransform.sizeDelta = new Vector2 (
				Mathf.Clamp(healthUpdate, 0, 100),
				theTransform.sizeDelta.y
			);
		}
	}
}
