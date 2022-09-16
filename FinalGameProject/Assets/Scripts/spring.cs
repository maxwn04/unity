using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring : MonoBehaviour {
	private Animator anim;

	public Transform groundcheck;

	public Rigidbody2D rb2d;

	public float velocityX;
	public float velocityY;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb2d = GameObject.Find ("player").GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		

	}
	public void OnTriggerEnter2D(Collider2D other) {
		rb2d.velocity = new Vector3(velocityX, velocityY);
		anim.SetBool ("activate", true);
		StartCoroutine (animation ());
	}
	public IEnumerator animation(){
		yield return new WaitForSeconds (.5f);
		anim.SetBool ("activate", false);
	}
}
