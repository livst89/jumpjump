using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {

	private GameController gameController; // Object for referring to the GameController script

	public float speed;
	public float jumpForce;		// Value must be set in the Platform prefab Inspector.

	public AudioClip Jump1;		// Jump sound clip

	void Start () {
		// Check to ensure that a GameController object is in the scene
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}

		rigidbody2D.velocity = transform.up * speed;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.name == "Player"){
			AudioSource.PlayClipAtPoint(Jump1, transform.position);		// Play jumping sound
			gameController.AddPoint();		// Add points to score in GameController
			other.gameObject.rigidbody2D.AddForce(new Vector2(0.0f,jumpForce));		// Push the Player upwards like a jump
			gameObject.SetActive(false); // Set the platform as inactive in the hierarchy
		}

		// Buggy, fix later!
		else if (other.gameObject.name == "Ground") {
			Debug.Log ("Platform hit ground");
			gameObject.SetActive(false); // Set the platform as inactive in the hierarchy
		}
	}
}