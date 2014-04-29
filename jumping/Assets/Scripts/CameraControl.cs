using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public GameObject player; // Object for referencing the Player avatar
	private Vector3 offset; // Vector to offset camera from the Player avatar
	
	// Use this for initialization
	void Start () {
		offset = transform.position; // Move camera to the off-set position
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3( 0,  player.transform.position.y + offset.y,  player.transform.position.z + offset.z); // Adjust the cameras positition to fit that of the Player avatar, and keep the offset from it
	}
}
