using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

	public bool alive = true;
	// Use this for initialization
	void start () {
		StartCoroutine (delete());
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * .5f * Time.deltaTime);
		if(transform.position.y<=-4 || !alive)
		{
			Destroy(gameObject);
		}

	}


	public IEnumerator delete(){
		yield return new WaitForSeconds(3);
		alive = false;
	}

}
