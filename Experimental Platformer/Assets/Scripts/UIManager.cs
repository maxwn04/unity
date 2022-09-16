using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	
	public Image imageDisplay;

	public int lives = 0;
	public int level = 0;

	public Text scoreText;
	public Text levelText;

	public GameObject titleScreen;
	public GameObject loseScreen;
	public GameObject youWin;

	public void MinusLives(){
		lives--;
		scoreText.text = "Lives: " + lives;
	}

	public void UpdateLives(){
		lives += 1;//score = score + 1;
		scoreText.text = "Lives: " + lives;
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
		if (lives >= 1) {
			youWin.SetActive (true);
		} else {
			loseScreen.SetActive(true);
		}
	}
	public void hideWin(){
		youWin.SetActive (false);
	}

}
