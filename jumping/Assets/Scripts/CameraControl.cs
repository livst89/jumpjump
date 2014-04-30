using UnityEngine;
using System.Collections;

/* Script for controlling the Main Camera in the Game scene
 * void Start() - Assign value to offset variable
 * void LateUpdate() - Change camera position along y-axis to follow Player object
 */

public class CameraControl : MonoBehaviour {
	
	public GameObject player; // Object for referencing the Player avatar
	private Vector3 offset; // Vector to offset camera from the Player avatar
	
	// Use this for initialization
	void Start () {
		offset = transform.position; // Save the cameras positon in the offset Vector3
	}
	
	// LateUpdate is called once per frame after all other Update functions
	void LateUpdate () {
		// Adjust the cameras positition to fit that of the Player avatar in the y-axis only, and keep the offset from it
		transform.position = new Vector3( 0,  player.transform.position.y + offset.y,  player.transform.position.z + offset.z);
	}
}
