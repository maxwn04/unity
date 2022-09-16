using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathScreen : MonoBehaviour {

	public player playerScript;
	private Animator anim;
	public SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		playerScript = GameObject.Find ("player").GetComponent<player> ();
		anim = GetComponent<Animator> ();
		renderer = GetComponent<SpriteRenderer> ();
		renderer.material.color = new Color (1, 1, 1, 0);
	}

	// Update is called once per frame
	void Update () {
		if (playerScript.dead.Equals (true)) {
			renderer.material.color = new Color(1,1,1,1);
			anim.SetBool ("dead", true);
			StartCoroutine(reset());
			//StartCoroutine (reset ());
		}/*else if (playerScript.dead.Equals (false)) {
			renderer.material.color = new Color (1, 1, 1, 0);
			anim.SetBool ("dead", false);
		}*/
	}
	public IEnumerator reset(){
		yield return new WaitForSeconds (1.5f);
		renderer.material.color = new Color (1, 1, 1, 0);
		anim.SetBool ("dead", false);
	}
}
