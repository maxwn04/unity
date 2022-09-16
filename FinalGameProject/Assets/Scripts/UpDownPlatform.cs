using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour {
	public bool movingUp = true;
	public bool switching = false;
	public int speed = 1;
	public float distance = 4f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (movingUp) {
			transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);
			if (!switching) {
				StartCoroutine (switchDirection ());

			}
			switching = true;
		} else if(!movingUp) {
			transform.Translate (new Vector3 (0, -1, 0) * speed * Time.deltaTime);
			if (!switching) {
				StartCoroutine (switchDirection ());

			}
			switching = true;
		}
	}

	public IEnumerator switchDirection(){
		yield return new WaitForSeconds(distance/speed);
		if(movingUp){
			movingUp = false;
		}else{
			movingUp = true;
		}
		switching = false;
	}


}
