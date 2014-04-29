using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public ScoreKeeper scoreKeeper;				// ScoreKeeper game object

	public GameObject PlatPre; 					// The gameobject platform, which the player jump in
	public Vector2 spawnValues; 				// The spawning platforms
	public Vector3 spawnOutside; 				// The spawning platform
	public float platCurrentY;					// Current y-position of platform being spawned
	public float platYIncrease;					// Amount by which to increase platform y-axis height
			
	public List<GameObject> pickUps;			// PickUps list for coin prefabs
	public GameObject pickupsContainer; 		// PickUps empty game object container
	public int maxPlats;						// Max amount of coins allowed in the

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

		scoreKeeper.resetScore();	// This functions is getting called at the beginning of the game so the score value is 0
		scoreKeeper.UpdateScore ();	// this function update the score function so it get updated so the counter can count scores.

		pickUps.AddRange(GameObject.FindGameObjectsWithTag("Platform"));	// Check for platform prefabs in the scene and add them to the pickUps List if there are any
		if (pickUps.Count == 0)	// If no platform prefabs have been added to the list, aka it's empty
			Debug.Log("No game objects are currently tagged with Platform");	// This will always be printed if there are no coins instantiated before the game starts
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves() {	// IEnumerator - coroutine is getting called in the beginning of the script 
		InstantiateFirstPlat ();
		while (true) {
			yield return new WaitForSeconds (spawnWait);
			InstantiatePlats ();	// "Instantiate" a platform
		}
	}

	GameObject InstantiateFirstPlat() {
		Vector3 spawnOutside = new Vector3 (0.5f, 1.1f, 10.0f);
		spawnOutside = Camera.main.ViewportToWorldPoint (spawnOutside); // Use spawnOutside vector to spawn the object outside the viewport
		platCurrentY = spawnOutside.y + platYIncrease;
		Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnOutside.y);
		Quaternion spawnRotation = Quaternion.identity;

		GameObject newPlat = (GameObject) Instantiate (PlatPre, spawnPosition, spawnRotation); // Instantiate a new platform prefab
		pickUps.Add (newPlat);	// Add it to the pickUps List
		newPlat.transform.parent = pickupsContainer.transform; // Keep the transform values from PickUp
		return newPlat;
	}

	GameObject InstantiatePlats() {	// Instantiate the platform
		Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), platCurrentY);
		Quaternion spawnRotation = Quaternion.identity;

		GameObject Plat = pickUps.Find (IsPlatFree); // Is there any free coin in the pickUps List?
		
		if (Plat != null) {	// If there is a free platform
			platCurrentY += platYIncrease;
			Plat.SetActive (true);	// ... set the platform to active...
			Plat.transform.position = spawnPosition;	// ... at the randomly generated position.
		}
		// Else if all coins in the pickUps List are active...

		else if(pickUps.Count < maxPlats){	// ... check if the current amount of platforms in the scene are below the max number of platforms allowed. If true:
			platCurrentY += platYIncrease;
			GameObject newPlat = (GameObject) Instantiate (PlatPre, spawnPosition, spawnRotation); // Instantiate a new platform prefab
			pickUps.Add (newPlat);	// Add it to the pickUps List
			newPlat.transform.parent = pickupsContainer.transform; // Keep the transform values from PickUp
		}
		return Plat;	// In any case, return the platform GameObject reference
	}

	// Check if any coin prefab is set to inactive
	bool IsPlatFree(GameObject plat) {
		return !plat.activeInHierarchy;
	}

	public void GameOver()	// Public void Gameover, loads the other level which is named "GameOver"
	{
		Application.LoadLevel ("GameOver");
	}
}
