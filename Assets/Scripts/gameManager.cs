using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	//score of player
	public int score = 0;

	//lives for player
	public int lives = 3;

	//high score for the game
	public int highScore = 0;

	//current level
	public int currentLevel = 1;

	//number of levels
	public int highestLevel = 3;

	public int totalScore = 0;

	HudManager hud; 

	//instance of the GM that can be accessed from anywhere
	public static gameManager instance;



	void Awake(){
		//check to see if instance has been assigned
		if (instance == null) {
			//assign it to the current object
			instance = this;
		}
		//make sure that is equal to the current object
		else if (instance != this) {

			instance.hud = FindObjectOfType<HudManager> ();

			//we do not need one so destroy it
			Destroy(gameObject);
		}


		//dont destroy this object when changing scenes
		DontDestroyOnLoad(gameObject);

		hud = FindObjectOfType<HudManager> ();
		startLevel ();

	}
	public IEnumerator StartCountdown()
	{
		score = 1000;
		while (score > 0)
		{
			yield return new WaitForSeconds(0.2f);
			score--;
			hud.ResetHud ();
		}
	}


	//increase player score


	//decrease lives by 1
	public void DecreaseLives(){
		lives--;

		//update lives text
		hud.ResetHud ();
		//SceneManager.LoadScene ("level" + currentLevel);

	}

	//game reset
	public void ResetGame(){

		//reset the score
		score = 0;

		totalScore = 0;
		//reset number of lives
		lives = 3;

		//current level to 1
		currentLevel = 1;

		//update score and lives text
		hud.ResetHud ();

		//load first level
		SceneManager.LoadScene("level1");


	}

	//send player to next level
	public void IncreaseLevel(){

		//check for next level
		if (currentLevel < highestLevel) {

			//increase level by 1
			currentLevel++;
		} else {
			currentLevel = 1;
		}
		StopCoroutine(StartCountdown());
		totalScore += score;
		if (totalScore > highScore) {
			highScore = totalScore;
		}
		//load next level
		SceneManager.LoadScene("nextLevel");
	}

	public void gameOver(){
		StopCoroutine (StartCountdown ());
		SceneManager.LoadScene("gameOver");
	}

	public void startLevel (){
		StartCoroutine (StartCountdown ());
		hud.ResetHud ();
	}
}