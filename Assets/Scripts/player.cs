using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public float walkSpeed;
	public float jumpSpeed;

	Vector3 movement;
	Vector3 spawn;
	Vector3 rotation;

	Rigidbody playerRB;

	public bool canJump;
	public bool grounded;

	public lava lavaScript;

	// Use this for initialization
	void Start () {
		lavaScript = GameObject.Find ("lava").GetComponent<lava> ();
		playerRB = GetComponent<Rigidbody>();
		canJump = true;
		grounded = true;
		walkSpeed = .2f;
		jumpSpeed = 10f;
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x <= -10.5) {
			playerRB.MovePosition(transform.position + new Vector3(1,0,0));
		}else if(transform.position.x >= 10.5){
			playerRB.MovePosition(transform.position +new Vector3(-1,0,0));
		}else if(transform.position.z <= -10.5){
			playerRB.MovePosition(transform.position +new Vector3(0,0,1));
		}else if(transform.position.z >= 10.5){
			playerRB.MovePosition(transform.position +new Vector3(0,0,-1));
		}else{
			WalkHandler ();
		}
		JumpHandler ();

		//CameraFollowPlayer ();
		/*
		if (transform.position.y <= -40) {
			gameManager.instance.DecreaseLives ();

			transform.position =  spawn;

		}
		*/
	}

	void WalkHandler(){
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");
		//float moveZ = transform.position.z + vAxis * walkSpeed * Time.deltaTime;
		float rotate = transform.rotation.y + hAxis * 2;
		//movement = new Vector3 (transform.position.x, transform.position.y, moveZ);
		transform.Translate (new Vector3(0,0,vAxis*walkSpeed));
		rotation = new Vector3 (0, hAxis*2, 0);
		//Quaternion deltaRotation = Quaternion.Euler (rotate * Time.deltaTime);
		transform.Rotate(rotation,Space.World);
	}

	void JumpHandler(){
		float yAxis = Input.GetAxis ("Jump");
		float moveY = yAxis * jumpSpeed;
		Vector3 jumpVector = new Vector3 (0, moveY, 0);
		if (yAxis > 0) {
			if (canJump && grounded) {
				playerRB.AddForce (jumpVector, ForceMode.VelocityChange);
				canJump = false;
				grounded = false;
			}
		} else {
			canJump = true;
		}
	}
	void OnCollisionEnter(Collision collision){
		grounded = true;
	}


	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("lava")) {
			gameManager.instance.DecreaseLives ();
			lavaScript.death ();
			if (gameManager.instance.lives == 0) {
				gameManager.instance.gameOver ();
			}
		}
		if (other.CompareTag ("goal")) {
			gameManager.instance.IncreaseLevel ();
		}
	}
}
