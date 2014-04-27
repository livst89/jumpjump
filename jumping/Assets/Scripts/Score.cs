using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	//	public Transform something; // this something instansiate on the void colission
	
	public Transform explosion;
	public int jumpSpeed = 3;
	
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.name == "Player"){
			// Debug.Log (" WUHHHU Debug");
			print(other.gameObject.GetComponent<PlayerControl>().score++);
			other.gameObject.rigidbody2D.velocity = Vector2.up * jumpSpeed;
			//		Instantiate(something, transform.position, Quaternion.identity);
			Destroy (gameObject); 
			
			
			//			other.gameObject.rigidbody2D.velocity = Vector2.up * jumpSpeed;
			
		} } 
	
	
}

