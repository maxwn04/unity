using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMovement : MonoBehaviour {
	//public Camera cam;
	// Use this for initialization
	public Transform endMarker = null; // create an empty gameobject and assign in inspector
	public float opacity;
	public SpriteRenderer title;
	public SpriteRenderer goButton;
	void Start () {
		//cam = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
		title = GameObject.Find ("Telet Logo").GetComponent<SpriteRenderer> ();
		goButton = GameObject.Find ("Start Button").GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		//cam.transform.position.y = Vector3.MoveTowards (cam, -350, 5.0f);
		transform.position = Vector3.Lerp(transform.position, endMarker.position, Time.deltaTime);
		if (opacity < 1) {
			opacity += 0.01f;
			title.material.color = new Color (title.material.color.r, title.material.color.g, title.material.color.b, opacity);
			goButton.material.color = new Color (goButton.material.color.r, goButton.material.color.g, goButton.material.color.b, opacity);
		}
}
}