﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpForce;

	InputManager inputManager;
	Rigidbody rb;

	private void Awake() {
		inputManager = GetComponent<InputManager>();
		rb = GetComponent<Rigidbody> ();
	}

	bool isGrounded;
	void OnCollisionStay() {
		isGrounded = true;
	}
		
	void FixedUpdate () {
		// Forward/backward
		rb.MovePosition (transform.position + transform.forward * inputManager.CurrentForward * Time.deltaTime * speed);
		// Rotation
		Vector3 tempRot = transform.rotation.eulerAngles;
		tempRot.y += inputManager.CurrentRotation * Time.deltaTime;
		rb.MoveRotation (Quaternion.Euler(tempRot));
		// Jump
		if (inputManager.CurrentJump == 1 && isGrounded) {
			isGrounded = false;
			rb.AddForce (Vector3.up*jumpForce, ForceMode.Impulse);
		}
	}
}