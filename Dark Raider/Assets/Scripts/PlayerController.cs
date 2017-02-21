﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public enum FACE_DIRECTION
	{
		LEFT = -1,
		RIGHT = 1
	}

	public FACE_DIRECTION direction = FACE_DIRECTION.RIGHT;

	public static PlayerController player = null;

	public bool canJump = true;
	public bool canMove = true;
	public bool isOnTheGround = false;

	public float jumpPower = 400.0f;
	public float jumpTimeout = 1.0f;
	public float maxSpeed = 40.0f;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public string jumpButton = "Jump";

	public BoxCollider2D feetCollider = null;
	public LayerMask groundLayer;

	private Rigidbody2D theRigidbody = null;
	private Transform theTransform = null;

	public static float Health {
		get { 
			return _health;
		}
		set { 
			_health = value;
			if (_health <= 0) {
				Die ();
			}
		}
	}

	[SerializeField]
	private static float _health = 100.0f;

	void Awake () {
		player = this;
		theRigidbody = GetComponent<Rigidbody2D> ();
		theTransform = GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void Jump() {
		if (!isOnTheGround || !canJump) {
			return;
		} else {
			theRigidbody.AddForce (Vector2.up * jumpPower);
			canJump = false;
			Invoke ("EnableJump", jumpTimeout);
		}
	}

	private void EnableJump () {
		canJump = true;
	}

	private bool GetGrounded() {
		Vector2 boxCenter = new Vector2 (theTransform.position.x, theTransform.position.y) + feetCollider.offset;
		Collider2D[] hitColliders = Physics2D.OverlapBoxAll (boxCenter, feetCollider.size, groundLayer);
		return hitColliders.Length > 0;
	}

	private void ChangeDirection() {
		direction = (FACE_DIRECTION)((int)direction * -1.0f);
		Vector3 localScale = theTransform.localScale;
		localScale.x *= -1.0f;
		theTransform.localScale = localScale;
	}

	void FixedUpdate () {
		if (!canMove || Health <= 0)
			return;

		isOnTheGround = GetGrounded ();

		float horizontal = CrossPlatformInputManager.GetAxis (horizontalAxis);
		theRigidbody.AddForce (Vector2.right * horizontal * maxSpeed);

		if ((horizontal < 0 && direction != FACE_DIRECTION.LEFT) || (horizontal > 0 && direction != FACE_DIRECTION.RIGHT)) {
			ChangeDirection ();
		}

		if (CrossPlatformInputManager.GetButton (jumpButton))
			Jump ();

		theRigidbody.velocity = new Vector2 (
			Mathf.Clamp (theRigidbody.velocity.x, -maxSpeed, maxSpeed),
			Mathf.Clamp (theRigidbody.velocity.y, -Mathf.Infinity, jumpPower)
		);
	}

	void OnDestroy() {
		player = null;
	}

	static void Die() {
		Destroy (PlayerController.player.gameObject);
	}

	public static void Reset() {
		Health = 100.0f;
	}
}
