using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour {
	public Collider2D c;
	public GameObject playerC;
	// Use this for initialization
	void Start () {
		c.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerC.transform.position.y > c.transform.position.y) {
			c.isTrigger = false;
		} else if(playerC.transform.position.y<c.transform.position.y){
			c.isTrigger = true;
		}


	}
}
