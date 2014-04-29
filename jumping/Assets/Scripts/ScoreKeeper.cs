using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	private int score;
	public GUIText scoreText;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public int GetScore() {
		return score;
	}

	public void AddPoint () {
		score += 10;
		UpdateScore ();
	}

	public void resetScore() {
		score = 0;
	}

	public void UpdateScore(){
		scoreText.text = "Score: " + score;
	}
}
