using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineHorizantal : MonoBehaviour {
	public bool movingRight = true;
	public bool switching = false;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (movingRight) {
			transform.Translate (new Vector3 (7.5f, 0, 0) * Time.deltaTime);
			if (!switching) {
				StartCoroutine (switchDirection ());

			}
			switching = true;
		} else if(!movingRight) {
			transform.Translate (new Vector3 (-7.5f, 0, 0) * Time.deltaTime);
			if (!switching) {
				StartCoroutine (switchDirection ());

			}
			switching = true;
		}
	}

	public IEnumerator switchDirection(){
		yield return new WaitForSeconds(1f);
		if(movingRight){
			movingRight = false;
		}else{
			movingRight = true;
		}
		switching = false;
	}


}
