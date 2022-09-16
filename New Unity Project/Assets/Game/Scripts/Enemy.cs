using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject explodePrefab;
	public UIManager uiManagerScript;
	public AudioSource explosionSound;


	public float speed = 1.0f;
	//add a boolean variable to control when the Enemy is hit by the Player or a Laser
	public bool hit = false;
	// Use this for initialization
	void Start () {
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
		explosionSound = GetComponent<AudioSource> ();
			
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if(uiManagerScript.titleScreen.activeInHierarchy == true)
		{
			Destroy(gameObject);
		}

		if(transform.position.y < -7f || hit){
			MoveToRandom();
			hit = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name.Contains("laser") || other.name.Contains("Triple Shot")){
			hit = true;
			Instantiate(explodePrefab, transform.position, Quaternion.identity);
			Destroy (other.gameObject);
			uiManagerScript.UpdateScore();
			explosionSound.Play();

		}
		if (other.name.Contains ("Player")) {
			hit = true;
			Instantiate(explodePrefab, transform.position, Quaternion.identity);
			explosionSound.Play();

		}
	}

	public void MoveToRandom(){
		float randomX = Random.Range(-9f,9f);
		transform.position = new Vector3(randomX, 7f, 0);
	}

}
