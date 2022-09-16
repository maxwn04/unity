using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireJump : MonoBehaviour {

	private Rigidbody2D rb2d;

	public float speed = 15f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -6) {
			rb2d.velocity = new Vector3 (0, speed, 0);
		}
	}


}
