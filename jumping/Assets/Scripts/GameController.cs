using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Script for controlling the course of the game.
 * void Start() - Checks for object tagged "ScoreKeeper", calling scoreKeeper.ResetScore() and scoreKeeper.UpdateScore(), checking scene for platforms to add to List, calling pawnWaves ()
 * IEnumerator SpawnWaves() - Coroutine, calls InstantiateFirstPlat() and InstantiatePlats()
 * GameObject InstantiateFirstPlat() - Spawns the first platform outside the top of the viewport
 * GameObject InstantiatePlats() - Spawns all following platforms
 * bool IsPlatFree(GameObject plat) - Check scene if there are any inactive platforms in the hierarchy
 * void GameOver() - Load GameOver scene
 */

public class GameController : MonoBehaviour {

	public ScoreKeeper scoreKeeper;	// ScoreKeeper game object

	public GameObject PlatPre;	// The gameobject platform, which the player jump into
	public Vector2 spawnValues;	// Variable containing the values for spawn position of platforms, set in Inspector
	public Vector3 spawnOutside;	// Variable for containing the y-axis spawn position of the first platform
	public float platCurrentY;	// Current y-position of the platform being spawned
	public float platYIncrease;	// Amount by which to increase platform y-axis height
			
	public List<GameObject> pickUps;	// PickUps list for platform prefabs
	public GameObject pickupsContainer;	// PickUps empty game object container
	public int maxPlats;	// Max amount of platforms allowed in the scene

	public float spawnWait; 			

	// Use this for initialization
	void Start() {
		// Check to ensure that a ScoreKeeper object is in the scene
		GameObject scoreKeeperObject = GameObject.FindWithTag ("ScoreKeeper"); // Search scene for game objects with the tag "ScoreKeeper"
		if (scoreKeeperObject != null) // If one is found...
		{
			scoreKeeper = scoreKeeperObject.GetComponent <ScoreKeeper>();	// ... get the ScoreKeeper script component
		}
		if (scoreKeeper == null) // If one is not found...
		{
			Debug.Log("Cannot find 'Score' script");	// Debugging to show if there is a mistake. 
		}

		scoreKeeper.ResetScore();	// Sets score value to 0
		scoreKeeper.UpdateScore();	// Updates the gui text displaying the score

		pickUps.AddRange(GameObject.FindGameObjectsWithTag("Platform"));	// Check for platform prefabs in the scene and add them to the pickUps List if there are any
		if (pickUps.Count == 0)	// If no platform prefabs have been added to the list, aka it's empty
			Debug.Log("No game objects are currently tagged with Platform");	// This will always be printed if there are no platforms instantiated before the game starts
		StartCoroutine (SpawnWaves ()); // Starting the coroutine to spawn platforms in the scene
	}

	IEnumerator SpawnWaves() {	// IEnumerator - coroutine is getting called in the Start function
		InstantiateFirstPlat(); // First platform is instantiated over the top of the viewport
		while(true) { // Ensure the platforms keep spawning for the entire duration of the scene
			yield return new WaitForSeconds(spawnWait); // Delay between spawning of platforms
			InstantiatePlats();	// "Spawn" a platform
		}
	}

	private GameObject InstantiateFirstPlat() {
		Vector3 spawnOutside = new Vector3 (0.5f, 1.1f, 10.0f); // V3 with coordinates outside the top of the viewport
		spawnOutside = Camera.main.ViewportToWorldPoint (spawnOutside); // Use spawnOutside vector to spawn the object outside the viewport on top
		platCurrentY = spawnOutside.y + platYIncrease; // Increase the y-axis spawn value for the following platform
		Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), spawnOutside.y); // Random x-axis value, y-axis value outside the viewport
		Quaternion spawnRotation = Quaternion.identity; // Quaternion... stuff.

		GameObject newPlat = (GameObject) Instantiate (PlatPre, spawnPosition, spawnRotation); // Instantiate a new platform prefab
		pickUps.Add (newPlat);	// Add it to the pickUps List
		newPlat.transform.parent = pickupsContainer.transform; // Keep the transform values from PickUp
		return newPlat;
	}

	private GameObject InstantiatePlats() {	// Instantiate platform
		Vector2 spawnPosition = new Vector2 (Random.Range (-spawnValues.x, spawnValues.x), platCurrentY); // Random x-axis value, y-axis value at current y height
		Quaternion spawnRotation = Quaternion.identity; // Quaternion... stuff.

		GameObject Plat = pickUps.Find (IsPlatFree); // Is there any free platform in the pickUps List?
		
		if (Plat != null) {	// If there is a free platform
			platCurrentY += platYIncrease; // Increase y-axis spawn point height
			Plat.SetActive (true);	// ... set the platform to active...
			Plat.transform.position = spawnPosition;	// ... at the randomly generated position.
		}
		// Else if all coins in the pickUps List are active...
		else if(pickUps.Count < maxPlats){	// ... check if the current amount of platforms in the scene are below the max number of platforms allowed. If true:
			platCurrentY += platYIncrease; // Increase y-axis spawn point height
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

	// End Game function
	public void GameOver(){
		Application.LoadLevel ("GameOver"); // Loads the GameOver scene
	}
}
