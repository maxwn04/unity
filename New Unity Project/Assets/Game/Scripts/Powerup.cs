using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	public UIManager uiManagerScript;

	// Use this for initialization
	void Start () {
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * Time.deltaTime);
		if(transform.position.y < -7){
			Destroy(gameObject);
		}
		if(uiManagerScript.titleScreen.activeInHierarchy == true)
		{
			Destroy(gameObject);
		}


	}

}
