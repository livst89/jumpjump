﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

	public float maxSpeed = 10.0f;
	public float jumpForce;				// Set to 700.0f in the Player inspector
	private bool grounded = false;			// Whether or not the player is grounded.
	public Transform groundCheck;			// A position marking where to check if the player is grounded.
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	float minValX = -6.5f;
	float maxValX = 6.5f;

	public AudioClip Jump1;
	

	void FixedUpdate (){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		//grounded = Physics2D.Linecast(transform.position,groundCheck.position,  1 << LayerMask.NameToLayer("Ground"));

		Debug.Log (grounded);


		float move = Input.GetAxis ("Horizontal");

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		if (rigidbody2D.transform.position.x < minValX)
			rigidbody2D.transform.position = new Vector3 (minValX, transform.position.y, transform.position.z);
		if (rigidbody2D.transform.position.x > maxValX)
			rigidbody2D.transform.position = new Vector3 (maxValX, transform.position.y, transform.position.z);
	
	}

	void Update(){
		if(grounded && Input.GetKeyDown(KeyCode.Space)){
			Debug.Log ("Jump!");
			AudioSource.PlayClipAtPoint(Jump1, transform.position);
			grounded = false;
			rigidbody2D.AddForce(new Vector2(0.0f,jumpForce));
		}
	}
}
