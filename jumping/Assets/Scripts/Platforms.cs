using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {

	public GameController gameController; // Object for referring to the GameController script
	
	public int jumpSpeed = 7;

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
			gameController.AddPoint();
			other.gameObject.rigidbody2D.velocity = Vector2.up * jumpSpeed;
			Destroy (gameObject);
		}
	}
}