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
		cameraMoveScript = GameObject.Find ("MainCamera").GetComponent<cameraMove> ();
		uiManagerScript.HideTitle ();
		uiManagerScript.ShowTitle();
	}


	// Update is called once per frame
	void Update()
	{
		if(gameOver==true){
			uiManagerScript.gameOver();
			if(Input.GetKeyDown(KeyCode.Space)){
				Instantiate(playerPrefab, new Vector3 (0,-4.263771f,0), Quaternion.identity);
				uiManagerScript.HideTitle();
				gameOver = false;
				uiManagerScript.lives = 2;
				uiManagerScript.UpdateLives();
				uiManagerScript.level = 0;
				uiManagerScript.nextLevel ();
				cameraMoveScript.GetTarget ();
			}
		}else{
			uiManagerScript.HideTitle();
		}
	}

}
