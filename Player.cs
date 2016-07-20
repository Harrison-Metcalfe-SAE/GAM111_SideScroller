using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform myTransform;

	public float walkSpeed = 2.0f;
	public float jumpForce = 250.0f;
	private float distToGround;
	private float distToWall;
	
	//Facing Direction
	public GameObject playerModel;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		
		distToGround = myTransform.GetComponent<Collider>().bounds.extents.y;
		distToWall = myTransform.GetComponent<Collider>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update () {
			
		Controls ();
	}


	void Controls(){
	
		 //Move Right
		if (Input.GetKey ("d")) {
			myTransform.Translate(0f, 0f, walkSpeed * Time.deltaTime);
		}
		
		//Move Left
		if (Input.GetKey ("a")) {
			myTransform.Translate(0f, 0f, -walkSpeed * Time.deltaTime);
		} 
	
		//Jumping
		if (Input.GetKeyDown ("space") && CheckGrounded() == true) {
			myTransform.GetComponent<Rigidbody>().AddForce (0,jumpForce,0);
		}
	}

	//Raycast down to check if grounded
	public bool CheckGrounded(){
		return Physics.Raycast(myTransform.position, -Vector3.up, distToGround + 0.1f);
	}

}
