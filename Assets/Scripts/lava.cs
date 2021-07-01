using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (0, 1, 0) * Time.deltaTime * speed);
	}

	public void death(){
		transform.Translate(new Vector3(0,-10,0) * speed);
	}
}
