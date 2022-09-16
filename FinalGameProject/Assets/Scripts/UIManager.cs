using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	public Image imageDisplay;

	//public int deaths = 0;
	//public int level = 0;

	//public Text levelText;
	public Text deathsText;
	public Text endText;
	public player playerScript;


	//lives Text

	void Awake(){
		DontDestroyOnLoad(gameObject);
		deathsText = GameObject.Find ("deathText").GetComponent<Text> ();
		endText = GameObject.Find ("endingText").GetComponent<Text> ();
		playerScript = GameObject.Find ("player").GetComponent<player> ();
		//levelText = GameObject.Find ("levelText").GetComponent<Text> ();

	}

	// Use this for initialization
	void Start () {

		ResetUi ();

	}

	public void ResetUi(){


		deathsText.text = "Deaths: " + GameManager.instance.deaths/2;
		//levelText.text = "Level " + GameManager.instance.currentLevel;

	}
	public void theEnd(){
		endText.text = "To be continued...";
	}
	public void theEndReset(){
		Destroy (gameObject);
	}


	/*
	public void die(){
		deaths++;
		scoreText.text = "Deaths: " + deaths;
	}


	public void ShowTitle(){
		titleScreen.SetActive(true);

	}


	public void HideTitle(){
		titleScreen.SetActive(false);
		youWin.SetActive (false);
		loseScreen.SetActive (false);
	}

	public void lose(){
		loseScreen.SetActive(true);
	}

	public void hideLose(){
		loseScreen.SetActive (false);
	}

	public void nextLevel(){
		level++;
		levelText.text = "Level " + level;
	}


	public void gameOver(){
		if (deaths >= 1) {
			youWin.SetActive (true);
		} else {
			loseScreen.SetActive(true);
		}
	}

	public void hideWin(){
		youWin.SetActive (false);
	}
*/

}
