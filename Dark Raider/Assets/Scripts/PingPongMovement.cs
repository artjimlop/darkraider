using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour {

	private Transform theTransform = null;
	private Vector3 originPosition = Vector3.zero;
	public Vector3 moveDirection = Vector3.zero;
	public float distance = 3.0f;

	void Awake () {
		theTransform = GetComponent<Transform> ();
		originPosition = theTransform.position;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		theTransform.position = originPosition + moveDirection * Mathf.PingPong (Time.time, distance);
	}
}
