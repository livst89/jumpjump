using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public ScoreKeeper scoreKeeper;		// ScoreKeeper game object

	public GameObject PlatPre;
	public Vector2 spawnValues;
	public Vector3 spawnOutside;

	public List<GameObject> pickUps;	// PickUps list for coin prefabs
	public GameObject pickupsContainer; // PickUps empty game object container
	public int maxPlats;				// Max amount of coins allowed in the scene

	//private bool gameOver;

	public float spawnWait;

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

		scoreKeeper.resetScore();
		scoreKeeper.UpdateScore ();
		//gameOver = false;
		pickUps.AddRange(GameObject.FindGameObjectsWithTag("Platform")); // Check for Coin prefabs in the scene and add them to the pickUps List if there are any
		if (pickUps.Count == 0) // If no Coin prefabs have been added to the list, aka it's empty
			Debug.Log("No game objects are currently tagged with Coin"); // This will always be printed if there are no coins instantiated before the game starts
		StartCoroutine (SpawnWaves ());
	}

/*	void Awake() {
		DontDestroyOnLoad(scoreText);
		Debug.Log("Don't destroy score");
	}*/

	IEnumerator SpawnWaves() {
		while (true) {
			InstantiatePlat ();

			yield return new WaitForSeconds (spawnWait);
		}
	}

	GameObject InstantiatePlat() {
		Vector3 spawnOutside = new Vector3 (0.5f, 1.1f, 10.0f);
		spawnOutside = Camera.main.ViewportToWorldPoint (spawnOutside);
		Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnOutside.y);
		Quaternion spawnRotation = Quaternion.identity;

		GameObject Plat = pickUps.Find (IsPlatFree); // Is there any free coin in the pickUps List?
		
		if (Plat != null) { // If there is a free coin
			if(Plat.activeInHierarchy == false){ // If the coin is inactive...
				Plat.SetActive (true); // ... set the coin to active...
				Plat.transform.position = spawnPosition; // ... at the randomly generated position.
			}
		}
		// Else if all coins in the pickUps List are active...
		else if(pickUps.Count < maxPlats){ // ... check if the current amount of coins in the scene are below the max number of coins allowed. If true:
			GameObject newPlat = (GameObject) Instantiate (PlatPre, spawnPosition, spawnRotation); // Instantiate a new coin prefab
			pickUps.Add (newPlat); // Add it to the pickUps List
			newPlat.transform.parent = pickupsContainer.transform; // Keep the transform values from PickUp
		}
		return Plat; // In any case, return the coin GameObject reference
	}

	// Check if any coin prefab is set to inactive
	bool IsPlatFree(GameObject plat) {
		return !plat.activeInHierarchy;
	}

	public void GameOver()
	{
		Application.LoadLevel ("GameOver");
	}
}
