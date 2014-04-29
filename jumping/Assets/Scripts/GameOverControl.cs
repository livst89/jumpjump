using UnityEngine;
using System.Collections;

public class GameOverControl : MonoBehaviour {

	private ScoreKeeper scoreKeeper; 		// Object for referring to the ScoreKeeper script
	public GUIText finalScoreText;			// Guitext which shows the final score 

	// Use this for initialization
	void Start () {
		// Check to ensure that a ScoreKeeper object is in the scene
		GameObject scoreKeeperObject = GameObject.FindWithTag ("ScoreKeeper");
		if (scoreKeeperObject != null)
		{
			scoreKeeper = scoreKeeperObject.GetComponent <ScoreKeeper>(); // gets the ScoreKeeper script. 
		}
		if (scoreKeeper == null)
		{
			Debug.Log ("Cannot find 'Score' script"); //Debugging to show if there is a mistake. 
		}

		int finalScore = scoreKeeper.GetScore();				//Gets the final score, when the game ends
		finalScoreText.text = "Final score: " + finalScore;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
