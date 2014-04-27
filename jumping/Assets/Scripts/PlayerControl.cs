using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		public int jump = 4;
		public Transform speed;

	public int jumpSpeed;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{

				//		transform.position += new Vector2(0, 0.5f);

				if (Input.GetKey (KeyCode.D)) {
						transform.Translate (Vector2.right * 4f * Time.deltaTime);
						transform.eulerAngles = new Vector2 (0, 0);


	
				}
				if (Input.GetKey (KeyCode.A)) {
						transform.Translate (-Vector2.right * 4f * Time.deltaTime);
						// transform.eulerAngles = new Vector2(0, 180); // This one is evil, and dosenøt work, becuase it is euler?
				}	
				if (Input.GetKey (KeyCode.W)) {
						transform.Translate (Vector2.up * 8f * Time.deltaTime);
				}
		}

//		void OnCollisionEnter2D (Collision2D other)
//		{
//
//				if (other.gameObject.name == "Platform") {
//						print ("Collided with platform");
//			rigidbody2D.velocity =  Vector2.up * jumpSpeed;
//						Destroy(other.gameObject);
//				}
//		}
}
