using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

	//score Text
	public Text scoreLabel;

	//lives Text
	public Text livesLabel;


	void Awake(){

		scoreLabel = GameObject.Find ("ScoreText").GetComponent<Text> ();
		livesLabel = GameObject.Find ("LivesText").GetComponent<Text> ();

	}

	// Use this for initialization
	void Start () {

		ResetHud ();

	}

	public void ResetHud(){


		scoreLabel.text = "Score: " + gameManager.instance.score;
		livesLabel.text = "Lives: " + gameManager.instance.lives;

	}



}