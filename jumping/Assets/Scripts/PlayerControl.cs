﻿using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		public int jump = 4;
		public Transform speed;
	  public int score = 0; // SCOOOOOOOOOOOOORREEEE

	public AudioSource Jump1;
	public int jumpSpeed;

	void start (){
	
		Jump1 = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip myJump1;	
		myJump1 = (AudioClip)Resources.Load ("Sounds/Jump1");
		Jump1.clip = myJump1;
		
	}

		void FixedUpdate ()
		{

				if (Input.GetKey (KeyCode.D)) {
						transform.Translate (Vector2.right * 4f * Time.deltaTime);
						transform.eulerAngles = new Vector2 (0, 0);


	
				}
				if (Input.GetKey (KeyCode.A)) {
						transform.Translate (-Vector2.right * 4f * Time.deltaTime);
				}	
				if (Input.GetKey (KeyCode.W)) {
						transform.Translate (Vector2.up * 8f * Time.deltaTime);
			Jump1.Play ();
				}
	
	}
	void OnGUI() {
		GUI.Label(new Rect (20, 20, 100, 40), "Score: " + score + ""); // this is the giu text. 
		
	}
}
