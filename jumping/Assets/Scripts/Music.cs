using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	 public AudioSource Jump1;
	 public AudioSource Platform;

	// Use this for initialization
	void Start () {
		// AUDIO

	
	}
	
	// Update is called once per frame
	void Update () {

		Jump1 = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip myJump1;	
		myJump1 = (AudioClip)Resources.Load ("Sounds/Jump1");
		Jump1.clip = myJump1;


 	//		GameObject theAudio = GameObject.Find("kaj");

		if(Input.GetKey(KeyCode.W)){
			Jump1.Play();
		}

	//	Audio audioScript = theAudio.GetComponent<Audio> ();

	//	audioScript.Jump1.Play ();
	//	audioScript.Platform.Play ();


	
	}
}
