using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeUIManager : MonoBehaviour {
	public GameObject transitionScreen;
	void Start(){
		transitionScreen.SetActive (false);
	}
	public void startGame(){
		transitionScreen.SetActive (true);
		StartCoroutine (startGameTime ());
			//SceneManager.LoadScene ("level1");
	}
	public IEnumerator startGameTime(){
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene ("level1");
	}
	public void showCredit(){
		transitionScreen.SetActive (true);
		SceneManager.LoadScene ("CreditScene");
	}
	public IEnumerator showCreditTime(){
		yield return new WaitForSeconds (.5f);
		SceneManager.LoadScene ("CreditScene");
	}
	public void returnStart(){
		//transitionScreen.SetActive (true);
		SceneManager.LoadScene ("Start");
	}

}
