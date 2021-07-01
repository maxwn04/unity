using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour {

	public Text score;
	public Text totalScore;
	// Use this for initialization
	void Start () {
		score.text = gameManager.instance.score.ToString();
		totalScore.text = gameManager.instance.totalScore.ToString();
	}


	// Update is called once per frame
	public void next () {
		SceneManager.LoadScene("level"+ gameManager.instance.currentLevel);
		gameManager.instance.startLevel ();
	}
}
