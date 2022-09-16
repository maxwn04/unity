using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {
	
	public Rigidbody2D player;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x >= 0) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, -10);
		}

		if (player.transform.position.y >= 5) {
			transform.position = new Vector3 (transform.position.x, player.transform.position.y, -10);

		}
		if (player.transform.position.y <= 5) {
			transform.position =new Vector3 (transform.position.x, 0, -10);
		
		}

	}
	public void GetTarget(){
		player = GameObject.Find ("player(Clone)").GetComponent<Rigidbody2D> ();
	}
}
