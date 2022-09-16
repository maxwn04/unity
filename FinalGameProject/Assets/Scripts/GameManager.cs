
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool gameOver = true;

	public GameObject playerPrefab;

	public UIManager uiManagerScript;

	public cameraMove cameraMoveScript;

	void Start() {
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
		cameraMoveScript = GameObject.Find ("Main Camera").GetComponent<cameraMove> ();
		uiManagerScript.HideTitle ();
		uiManagerScript.ShowTitle();
	}


	// Update is called once per frame
	void Update()
	{
		if(gameOver==true){
			uiManagerScript.gameOver();
			if(Input.GetKeyDown(KeyCode.Space)){
				Instantiate(playerPrefab, new Vector3 (-4,0f,0), Quaternion.identity);
				uiManagerScript.HideTitle();
				gameOver = false;
				uiManagerScript.deaths = 0;
				uiManagerScript.level = 0;
				uiManagerScript.nextLevel ();
				cameraMoveScript.GetTarget ();
			}
		}else{
			uiManagerScript.HideTitle();
		}
	}

}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;

	public UIManager uiManagerScript;

	public cameraMove cameraMoveScript;


	//lives for player
	public int deaths = 0;

	//high score for the game
	//public int highScore = 0;

	//current level
	public int currentLevel = 1;

	//number of levels
	public int highestLevel = 3;

	//instance of the GM that can be accessed from anywhere
	public static GameManager instance;

	void Start(){
		//check to see if instance has been assigned
		if (instance == null) {
			//assign it to the current object
			instance = this;
		}


		//make sure that is equal to the current object
		else if (instance != this) {

			//instance.hud = FindObjectOfType<HudManager> ();

			//we do not need one so destroy it
			Destroy(gameObject);
		}

		//dont destroy this object when changing scenes
		DontDestroyOnLoad(gameObject);
		cameraMoveScript = GameObject.Find ("Main Camera").GetComponent<cameraMove> ();
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
		uiManagerScript.ResetUi ();
	}
		

	//increase player score
	/*
	public void IncreaseScore(int amount){
		score += amount;

		Debug.Log("new score: " + score);

		//is there a new high score
		if (score > highScore) {
			highScore = score;
			Debug.Log("new record: " + highScore);
		}

		//update score text
		hud.ResetHud ();
	}
	*/
	//decrease lives by 1
	public void die(){
		deaths++;

		//update lives text
		uiManagerScript.ResetUi ();

		Debug.Log("num lives: " + deaths);

		//SceneManager.LoadScene ("level" + currentLevel);

	}

	//game reset
	public void ResetGame(){

		//reset the score
		deaths = 0;

		//reset number of lives
		currentLevel = 0;



		//update score and lives text
		uiManagerScript.ResetUi ();

		//load first level
		SceneManager.LoadScene("level1");


	}
	public void Reset(){
		deaths = 0;
		uiManagerScript.ResetUi ();
		currentLevel = 0;
	}
		

	//send player to next level
	public void IncreaseLevel(){

		//check for next level
		if (currentLevel < highestLevel) {

			//increase level by 1
			currentLevel++;
		} else {
			//currentLevel = 1;
		}


		//load next level
		SceneManager.LoadScene("level"+currentLevel);
		cameraMoveScript.GetTarget ();
	}
	public void gameOver(){
		SceneManager.LoadScene("gameOver");
	}
}

