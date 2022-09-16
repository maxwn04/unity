using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float horizontalInput = Input.GetAxis("Horizontal");

		transform.Translate(new Vector3(1f, 0, 0) * Time.deltaTime * speed * horizontalInput);

		float verticalInput = Input.GetAxis("Vertical");

		transform.Translate(new Vector3(0, 1f, 0) * Time.deltaTime * speed * verticalInput);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name.Contains("FireBall")){
			transform.position = new Vector3(-7.44f,-3.42f,0);

		}
	}

}
