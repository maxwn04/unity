﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBall : MonoBehaviour {
	public bool movingUp = true;
	public bool switching = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (movingUp) {
			transform.Translate (new Vector3 (0, 3, 0) * Time.deltaTime);
			if (!switching) {
				StartCoroutine (switchDirection ());

			}
			switching = true;
		} else if(!movingUp) {
			transform.Translate (new Vector3 (0, -3, 0) * Time.deltaTime);
			if (!switching) {
				StartCoroutine (switchDirection ());

			}
			switching = true;
		}
	}

	public IEnumerator switchDirection(){
		yield return new WaitForSeconds(.83f);
		if(movingUp){
			movingUp = false;
		}else{
			movingUp = true;
		}
		switching = false;
	}


}
