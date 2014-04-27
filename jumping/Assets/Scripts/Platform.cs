using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public Transform explosion;
	public int jumpSpeed = 7;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D other) {
		//Debug.Log (other.gameObject.name);
		if(other.gameObject.name == "kaj"){	
			other.gameObject.rigidbody2D.velocity = Vector2.up * jumpSpeed;
			Destroy (gameObject);
			//print(other.gameObject.GetComponent<Moooove>().life--);
		//Instantiate(explosion, transform.position, Quaternion.identity);
		//Destroy(gameObject);
		}
	}
}