using UnityEngine;
using System.Collections;

/* Script controlling player movement left/right plus jump, also checks if player hits ground after gaining points in order to end the game
 * void Start() - Checks scene for objects tagged "GameController" and "ScoreKeeper" and gets script components
 * void FixedUpdate() - Grounded check, horizontal axis movement with boundaries
 * void Update() - Jump and EndGame check, checks scoreKeeper.GetScore(), calls gameController.GameOver()
 */

public class PlayerControl : MonoBehaviour
{
	private GameController gameController; // Object for referring to the GameController script
	private ScoreKeeper scoreKeeper; // Object for referring to the GameController script

	public float maxSpeed; // Player max movement speed, set to 15.0f in the Player inspector
	public float jumpForce;	// Player jump force, set to 700.0f in the Player inspector
	private bool grounded = false;	// Whether or not the player is grounded
	public Transform groundCheck;	// A position marking where to check if the player is grounded
	float groundRadius = 0.2f;	// Radius within which to check if overlapping with Ground
	public LayerMask whatIsGround; // LayerMask containing definition of which layers are considered Ground, set in Inspector

	// Boundaries so the player doesn't run off the sides of the game
	float minValX = -5.5f;
	float maxValX = 5.5f;

	public AudioClip Jump1; // Jump clip 1

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
			Debug.Log ("Cannot find 'Score' script");	// Debugging to show if there is a mistake. 
		}
	}

	// This function is called every fixed framerate frame
	void FixedUpdate (){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround); // Boolean value, true if groundRadius overlaps with the Ground layer

		float move = Input.GetAxis ("Horizontal"); // Input for moving left/right, f.ex. A and D or arrow keys

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y); // Add velocity to Player so it moves in the direction of the input gotten above
		if (rigidbody2D.transform.position.x < minValX) // Checking left boundary
			rigidbody2D.transform.position = new Vector3 (minValX, transform.position.y, transform.position.z); // Resetting x-axis position to minValX
		if (rigidbody2D.transform.position.x > maxValX) // Checking right boundary
			rigidbody2D.transform.position = new Vector3 (maxValX, transform.position.y, transform.position.z);	// Resetting x-axis position to maxValX
	
	}

	// Update is called once per frame
	void Update(){
		if(grounded && Input.GetKeyDown(KeyCode.Space)){ // If Player is grounded and the Space key is pressed
			AudioSource.PlayClipAtPoint(Jump1, transform.position); // Play jump audio
			grounded = false; // Set grounded to false
			rigidbody2D.AddForce(new Vector2(0.0f,jumpForce)); // Add force to make Player jump up
		}
		int score = scoreKeeper.GetScore(); // Get score value from ScoreKeeper
		if(grounded && score > 0){ // If player is grounded (again) after gaining points (by jumpin into platforms)
			gameController.GameOver(); // Call GameOver function in GameController
		}
	}
}
