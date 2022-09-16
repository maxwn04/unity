using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {
	
	public Rigidbody2D player;
	public player playerScript;
	public float opacity = 0;
	public SpriteRenderer teleporationScreen;
	//public SpriteRenderer deathScreen;
	public GameObject Background1;
	public GameObject Background2;
	public GameObject Background3;
	public GameObject Background4;
	public GameObject Background;
	public float scaleFactor;
	public float camPos;
	public float prevCamPos;
	private Transform cam;

	public float rightBorder = 113;
	public float leftBorder = 2;
	public float bottomBorder = 25;
	public float topBorder = 45;
	// Use this for initialization
	void Start () {;
		//DontDestroyOnLoad(gameObject);
		//transform.position = new Vector3(0,3,-10);
		playerScript = GameObject.Find ("player").GetComponent<player> ();
		teleporationScreen = GameObject.Find ("TeleportationScreen").GetComponent<SpriteRenderer> ();
	//	deathScreen = GameObject.Find ("DeathScreen").GetComponent<SpriteRenderer> ();//
		teleporationScreen.material.color = new Color (teleporationScreen.material.color.r, teleporationScreen.material.color.g, teleporationScreen.material.color.b, opacity);
	//	deathScreen.material.color = new Color (deathScreen.material.color.r, deathScreen.material.color.g, deathScreen.material.color.b, opacity);

	}
	
	// Update is called once per frame
	void Update () {
		camPos = Camera.main.transform.position.x;
		scaleFactor = (camPos - prevCamPos);
		/*
		if (GameManager.instance.currentLevel.Equals (1)) {
			Background.SetActive (true);

		} else {
			Background.SetActive (false);

		}*/
		if (player.transform.position.x >= leftBorder && rightBorder >= player.transform.position.x) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, -10);
			Background1.transform.position = new Vector3 (Background1.transform.position.x - (scaleFactor / 15), Background1.transform.position.y, Background1.transform.position.z);
			Background2.transform.position = new Vector3 (Background2.transform.position.x - (scaleFactor / 10), Background2.transform.position.y, Background1.transform.position.z);
			Background3.transform.position = new Vector3 (Background3.transform.position.x - (scaleFactor / 5), Background3.transform.position.y, Background1.transform.position.z);
			Background4.transform.position = new Vector3 (Background4.transform.position.x - (scaleFactor / 2), Background4.transform.position.y, Background1.transform.position.z);

		} else if (player.transform.position.x <= leftBorder) {
			transform.position = new Vector3(leftBorder, transform.position.y, -10);
		}
		if (player.transform.position.y > 7  && player.transform.position.y < 20.5) {
			transform.position = new Vector3 (transform.position.x, 13f, transform.position.z);
			leftBorder = 113f;
			rightBorder = 158.6f;
		} else if (player.transform.position.y > 20) {
			transform.position = new Vector3 (transform.position.x, 25f, transform.position.z);
			//transform.position = new Vector3 (transform.position.x, 13f, transform.position.z);
			leftBorder = 158.6f;
			rightBorder = 158.6f;
			if (player.transform.position.y >= bottomBorder && topBorder >= player.transform.position.y) {
				transform.position = new Vector3 (transform.position.x, player.transform.position.y, -10);
			}

		} else {
			transform.position = new Vector3 (transform.position.x, .38f, transform.position.z);
		}

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

		//
		/*if (playerScript.dead.Equals (true)) {
			if (opacity < 1) {
				opacity += 0.1f;
				deathScreen.material.color = new Color (deathScreen.material.color.r, deathScreen.material.color.g, deathScreen.material.color.b, opacity);
			}
		} else {
			if(opacity > 0){
				opacity -= 0.1f;
				deathScreen.material.color = new Color (deathScreen.material.color.r, deathScreen.material.color.g, deathScreen.material.color.b, opacity);
			}
		}*/


		//transform.position = new Vector3 (transform.position.x, player.transform.position.y+1.5f, -10);



		prevCamPos = camPos;
	}
	public void GetTarget(){
		player = GameObject.Find ("player").GetComponent<Rigidbody2D> ();
		playerScript = GameObject.Find ("player").GetComponent<player> ();
	}
}
