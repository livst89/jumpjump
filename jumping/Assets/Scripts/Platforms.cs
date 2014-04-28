using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {

	public GameController gameController; // Object for referring to the GameController script
	
	public float jumpForce;		// Value must be set in the Platform prefab Inspector.

	public AudioClip Jump1;

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
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.name == "Player"){
			AudioSource.PlayClipAtPoint(Jump1, transform.position);
			gameController.AddPoint();
			other.gameObject.rigidbody2D.AddForce(new Vector2(0.0f,jumpForce));
			//other.gameObject.rigidbody2D.velocity = Vector2.up * jumpSpeed;
			Destroy (gameObject);
		}
	}
}