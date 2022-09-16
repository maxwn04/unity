using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class image : MonoBehaviour {


	public player playerScript;

	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find ("player").GetComponent<player>();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (!playerScript.teleport) {
			Destroy (gameObject);
		}
	}
}
