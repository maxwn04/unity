using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrollDiscrete : MonoBehaviour {
	public bool left;
	public float movement = 0;
	public player playerScript;
	public float stopPoint;
	public float startPoint;
	// Use this for initialization
	void Start () {
		left = true;
		stopPoint = Camera.main.transform.position.x + 21.5f;
		startPoint = Camera.main.transform.position.x;
		playerScript = GameObject.Find("player").GetComponent<player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Camera.main.transform.position.x < stopPoint && left == true) {
			Camera.main.transform.position = new Vector3 (Camera.main.transform.position.x + movement, Camera.main.transform.position.y, Camera.main.transform.position.z);
		} else {
			movement = 0f;
			stopPoint = Camera.main.transform.position.x + 21.5f;
		}
		if (playerScript.dead == true) {
			//left = true;
			StartCoroutine (deathCamera ());
		}


	}
	public void OnTriggerEnter2D(Collider2D other) {
			if(left == true){
				left = false;
				movement = -1f;
				//StartCoroutine (CameraChangeRight ());
			}
			else if(left == false){
				left = true;
				movement = 1f;
				//StartCoroutine (CameraChangeLeft ());
			}
	}
	/*public IEnumerator CameraChangeRight(){
		movement = -1.5f;
		yield return new WaitForSeconds (0.3f);
		movement = 0;
	}
	public IEnumerator CameraChangeLeft(){
		movement = 1.5f;
		yield return new WaitForSeconds (0.3f);
		movement = 0;
	}*/
	public IEnumerator deathCamera(){
		yield return new WaitForSeconds (1.5f);
		Camera.main.transform.position = new Vector3 (1.77f, 0.59f, -10f);
		stopPoint = startPoint + 21.5f;
	}
}
