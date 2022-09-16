using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoom : MonoBehaviour {

	public int rooms;
	public int[] roomBoundaryLeft;
	public int[] roomBoundaryRight;
	public int room;
	public SpriteRenderer teleporationScreen;
	public player playerScript;
	public Rigidbody2D player;
	public float opacity = 0;
	public 
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0,0,-10);
		playerScript = GameObject.Find ("player").GetComponent<player> ();
		teleporationScreen = GameObject.Find ("TeleportationScreen").GetComponent<SpriteRenderer> ();
		teleporationScreen.material.color = new Color (teleporationScreen.material.color.r, teleporationScreen.material.color.g, teleporationScreen.material.color.b, opacity);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerScript.teleport.Equals (true)) {
			if (opacity < 1) {
				opacity += 0.1f;
				teleporationScreen.material.color = new Color (teleporationScreen.material.color.r, teleporationScreen.material.color.g, teleporationScreen.material.color.b, opacity);
			}
		} else {
			if(opacity > 0){
				opacity -= 0.1f;
				teleporationScreen.material.color = new Color (teleporationScreen.material.color.r, teleporationScreen.material.color.g, teleporationScreen.material.color.b, opacity);
			}
		}

	}
}
