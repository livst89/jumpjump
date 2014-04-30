using UnityEngine;
using System.Collections;

/* Script controlling the score in the game
 * Awake() - Ensures ScoreKeeper object is not destroyed when loading new scene
 * GetScore() - Get function for accessing score
 * AddPoint() - Adds 10 points to score, calls UpdateScore()
 * ResetScore() - Sets score to 0
 * UpdateScore() - Updates the GUI text displaying score
 */

public class ScoreKeeper : MonoBehaviour {
	private int score;				 	// Variable for holding score value
	public GUIText scoreText; 	// GUI text element for displaying the score

	// This function is called when the script instance is being loaded
	void Awake() {
		DontDestroyOnLoad(transform.gameObject); // Allows ScoreKeeper object to stay active when switching to the EndGame scene
	}

	// Get the current score
	public int GetScore() {
		return score;
	}

	// Add 10 points to score and update GUI text displaying score
	public void AddPoint () {
		score += 10;
		UpdateScore ();
	}

	// Set score to 0
	public void ResetScore() {
		score = 0;
	}

	// Update GUI text displaying score
	public void UpdateScore(){
		scoreText.text = "Score: " + score;
	}
}
