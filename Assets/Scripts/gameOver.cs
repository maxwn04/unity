using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour {

	public Text highScore;
	public Text totalScore;
	// Use this for initialization
	void Start () {
		highScore.text = gameManager.instance.highScore.ToString();
		totalScore.text = gameManager.instance.totalScore.ToString();
	}


	// Update is called once per frame
	public void playAgain() {
		SceneManager.LoadScene("level1");
		gameManager.instance.ResetGame ();
		gameManager.instance.startLevel ();
	}
}
