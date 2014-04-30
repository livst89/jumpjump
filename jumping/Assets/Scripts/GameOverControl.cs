using UnityEngine;
using System.Collections;

/* Script controlling the GUI text displays in the GameOver scene
 * Start() - Checks scene for objects tagged "ScoreKeeper", updates GUI text displaying final score
 */

public class GameOverControl : MonoBehaviour {

	private ScoreKeeper scoreKeeper;	// Object for referring to the ScoreKeeper script
	public GUIText finalScoreText;	// Guitext which shows the final score 

	// Use this for initialization
	void Start () {
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

		int finalScore = scoreKeeper.GetScore();	// Gets the final score from ScoreKeeper when the game ends
		finalScoreText.text = "Final score: " + finalScore; // GUI text displays final score

	}
}
