using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineWacky : MonoBehaviour {
	public bool movingUp = true;
	public bool movingRight = true;
	public bool switchingH = false;
	public bool switchingV = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.Translate (new Vector3 (3f, 0, 0) * Time.deltaTime);
			if (!switchingH) {
				StartCoroutine (switchHDirection ());

			}
			switchingH = true;
		} else if(!movingRight) {
			transform.Translate (new Vector3 (-3f, 0, 0) * Time.deltaTime);
			if (!switchingH) {
				StartCoroutine (switchHDirection ());

			}
			switchingH = true;
		}
		if (movingUp) {
			transform.Translate (new Vector3 (0, 3, 0) * Time.deltaTime);
			if (!switchingV) {
				StartCoroutine (switchVDirection ());

			}
			switchingV = true;
		} else if(!movingUp) {
			transform.Translate (new Vector3 (0, -3, 0) * Time.deltaTime);
			if (!switchingV) {
				StartCoroutine (switchVDirection ());

			}
			switchingV = true;
		}
	}

	public IEnumerator switchVDirection(){
		yield return new WaitForSeconds(.8f);
		if(movingUp){
			movingUp = false;
		}else{
			movingUp = true;
		}
		switchingV = false;
	}

	public IEnumerator switchHDirection(){
		yield return new WaitForSeconds(2f);
		if(movingRight){
			movingRight = false;
		}else{
			movingRight = true;
		}
		switchingH = false;
	}
}
