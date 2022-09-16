using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
	public Animator anim;
	public GameObject obj;
	public AudioSource music;
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		music = gameObject.GetComponent<AudioSource>();
		Debug.Log (obj.transform.position.x);
		Debug.Log (obj.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 mouse = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		Ray ray;
		ray = Camera.main.ScreenPointToRay(mouse);
		RaycastHit hit;
		//Physics.ray
		/*if(Physics.Raycast(ray,out hit, 10))
		{*/
		//Debug.Log (Input.mousePosition.x-188.56f);
		if ((Input.mousePosition.x-188.56f > obj.transform.position.x + 110)
			&& (Input.mousePosition.x-188.56f < obj.transform.position.x + 200)
			&& (Input.mousePosition.y-105.06f > obj.transform.position.y - 20)
			&& (Input.mousePosition.y-105.06f < obj.transform.position.y + 40))
				anim.SetBool ("Active", true);//Debug.Log("Left");
			else
				anim.SetBool ("Active", false);//Debug.Log("Right");
	}

}
		
