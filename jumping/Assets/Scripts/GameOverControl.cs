using UnityEngine;
using System.Collections;

public class GameOverControl : MonoBehaviour {

	private ScoreKeeper scoreKeeper; // Object for referring to the GameController script
	public GUIText finalScoreText;

	// Use this for initialization
	void Start () {
		// Check to ensure that a ScoreKeeper object is in the scene
		GameObject scoreKeeperObject = GameObject.FindWithTag ("ScoreKeeper");
		if (scoreKeeperObject != null)
		{
			scoreKeeper = scoreKeeperObject.GetComponent <ScoreKeeper>();
		}
		if (scoreKeeper == null)
		{
			Debug.Log ("Cannot find 'Score' script");
		}

		int finalScore = scoreKeeper.GetScore();
		finalScoreText.text = "Final score: " + finalScore;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
