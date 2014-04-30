using UnityEngine;
using System.Collections;

/* Script controlling the behaviour of each platform prefab
 * void Start() - Check for GameController and ScoreKeeper tagged objects in scene
 * void Update() - Calls DespawnPlat()
 * void FixedUpdate() - Moves platforms down
 * GameObject OnCollisionEnter2D(Collision2D other) - Collision detection with object tagged "Player" (Play sound, add points to score, push player up, set game object to inactive)
 * void DespawnPlat() - Check platform y-axis position, set to inactive if too low
 */

public class Platforms : MonoBehaviour {

	private GameController gameController; 	// Object for referring to the GameController script
	private ScoreKeeper scoreKeeper; 				// Object for referring to the GameController script

	public float speed;											// Variable for storing platform downward movement speed value, set in Inspector
	public float jumpForce;									// Variable for storing Player jump boost speed value, set in Inspector

	public float checkYPos;									// Variable for storing a platforms current y-axis position
	public float despawnHeight; 						// Variable for storing value of what height platforms should despawn at, set in Inspector

	public AudioClip Jump1;									// Jump Audiosound

	// Use this for initialization
	void Start () {
		// Check to ensure that a GameController object is in the scene
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");	// Search scene for game objects with the tag "GameController"
		if (gameControllerObject != null)	// If one is found...
		{
			gameController = gameControllerObject.GetComponent <GameController>();	// ... get the GameController script component
		}
		if (gameController == null)	// If one is not found...
		{
			Debug.Log ("Cannot find 'GameController' script");	// Debugging to show if there is a mistake
		}

		// Check to ensure that a ScoreKeeper object is in the scene
		GameObject scoreKeeperObject = GameObject.FindWithTag ("ScoreKeeper"); // Search scene for game objects with the tag "ScoreKeeper"
		if (scoreKeeperObject != null) // If one is found...
		{
			scoreKeeper = scoreKeeperObject.GetComponent <ScoreKeeper>();	// ... get the ScoreKeeper script component
		}
		if (scoreKeeper == null) // If one is not found...
		{
			Debug.Log ("Cannot find 'Score' script");	// Debugging to show if there is a mistake
		}
	}

	// Update is called once per frame
	void Update(){
		DespawnPlat();
	}
	// This function is called every fixed framerate frame
	void FixedUpdate () {
		rigidbody2D.velocity = transform.up * speed;	// Moves platform down
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.name == "Player"){	//if this object colides with the other object named Player
			AudioSource.PlayClipAtPoint(Jump1, transform.position);	// Play jumping sound
			scoreKeeper.AddPoint();	// Add points to score in ScoreKeeper
			other.gameObject.rigidbody2D.AddForce(new Vector2(0.0f,jumpForce));	// Push the Player upwards like a jump
			gameObject.SetActive(false); // Set the platform as inactive in the hierarchy
		}
	}

	void DespawnPlat(){
		checkYPos = transform.position.y; // Store the platforms current y-axis position
		if(checkYPos <= despawnHeight) // If platform is lower on the y-axis than the despawn height...
			gameObject.SetActive(false); // ... set the platform as inactive in the hierarchy
	}
}