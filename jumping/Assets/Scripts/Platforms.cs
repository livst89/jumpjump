using UnityEngine;
using System.Collections;

public class Platforms : MonoBehaviour {
	
	public int jumpSpeed = 7;

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.name == "Player"){	
			other.gameObject.rigidbody2D.velocity = Vector2.up * jumpSpeed;
			Destroy (gameObject);
		}
	}
}