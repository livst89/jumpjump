using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		public int jump = 4;
		public Transform speed;

	public int jumpSpeed;

		void FixedUpdate ()
		{

				if (Input.GetKey (KeyCode.D)) {
						transform.Translate (Vector2.right * 4f * Time.deltaTime);
						transform.eulerAngles = new Vector2 (0, 0);


	
				}
				if (Input.GetKey (KeyCode.A)) {
						transform.Translate (-Vector2.right * 4f * Time.deltaTime);
				}	
				if (Input.GetKey (KeyCode.W)) {
						transform.Translate (Vector2.up * 8f * Time.deltaTime);
				}
		}
}
