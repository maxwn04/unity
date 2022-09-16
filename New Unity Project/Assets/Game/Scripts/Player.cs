using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject laserPrefab;
	public GameObject tripleLaserPrefab;
	public GameObject shipExplosionPrefab;
	public GameObject shieldGameObject;
	public GameObject fire1;
	public GameObject fire2;
	public UIManager uiManagerScript;
	public GameManager gameManagerScript;
	public AudioSource laserSound;
	public AudioSource explosionSound;
	public AudioSource powerUpSound;


	public float speed = 5.0f;
	public float fireRate = 0.5f;
	public float canFire = 0.0f;
	public int life = 3;

	public bool canTripleShot = false;
	public bool shieldOn = false;

	// Use this for initialization
	void Start () {
		/*Debug.Log ("Debug Works");
		Debug.Log("Name: " + name);
		Debug.Log("X pos: " + transform.position.x);
		Debug.Log(transform.position);
		*/
		fire1.gameObject.SetActive (false);
		fire2.gameObject.SetActive (false);
		transform.position = new Vector3(0, 0, 0);
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();

		if(uiManagerScript!=null){
			uiManagerScript.UpdateLives(life);
		}

		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		AudioSource[] audios = GetComponents<AudioSource>();
		laserSound = audios[0];
		explosionSound = audios[1];
		powerUpSound = audios[2];


	}
	
	// Update is called once per frame
	void Update()
	{

		float horizontalInput = Input.GetAxis("Horizontal");

		transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * horizontalInput);

		float verticalInput = Input.GetAxis("Vertical");

		transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed * verticalInput);

		if(transform.position.x > 9.4f)
		{
			transform.position = new Vector3(-9.4f, transform.position.y, 0);
		}
		else if (transform.position.x < -9.4f)
		{
			transform.position = new Vector3(9.4f, transform.position.y, 0);
		}  
		else if(transform.position.y > 5.6f)
		{
			transform.position = new Vector3(transform.position.x, -5.6f, 0);
		}
		else if (transform.position.y < -5.6f)
		{
			transform.position = new Vector3(transform.position.x, 5.6f, 0);
		}     
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			//cooldown
			if(Time.time > canFire){
				laserSound.Play();

				//powerup - triple shot
				if(canTripleShot){
					Instantiate(tripleLaserPrefab, transform.position + new Vector3(0,.3f,0), Quaternion.identity);
				}//end canTripleshot check
				else{
					Instantiate(laserPrefab, transform.position + new Vector3(0,.3f,0), Quaternion.identity);
				}
				canFire = Time.time + fireRate;
			}//end time check
		}// end fire

		if(shieldOn){
			shieldGameObject.SetActive(true);
		}else{
			shieldGameObject.SetActive(false);
		}

		if (life <= 0) {
			Instantiate (shipExplosionPrefab, transform.position, Quaternion.identity);
			Destroy (gameObject);
			gameManagerScript.gameOver=true;
			uiManagerScript.ShowTitle();
		} else if (life <= 1) {
			fire1.gameObject.SetActive (true);
		}else if (life <= 2) {
			fire2.gameObject.SetActive (true);
		}
		uiManagerScript.UpdateLives(life);
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name.Contains("PowerupTripleShot")){
			canTripleShot = true;
			Destroy(other.gameObject);
			StartCoroutine(TripleShotPowerDown());
			powerUpSound.Play();
		}

		if(other.name.Contains("PowerupSpeed")){
			speed = speed + 5f;
			Destroy(other.gameObject);
			StartCoroutine(SpeedBoostPowerDown());
			powerUpSound.Play();
		}
		if(other.name.Contains("shieldPowerup")){
			shieldOn = true;
			Destroy(other.gameObject);
			StartCoroutine(shieldOff());
			powerUpSound.Play();
		}
		if (other.name.Contains ("Enemy") && !shieldOn) {
			other.GetComponent<Enemy> ().MoveToRandom ();
			life = life - 1;
			explosionSound.Play ();
		} else if (shieldOn == true) {
			uiManagerScript.UpdateScore ();
			explosionSound.Play ();
		}
			
	}

	public IEnumerator TripleShotPowerDown(){
		yield return new WaitForSeconds(7);
		canTripleShot = false;
	}

	public IEnumerator SpeedBoostPowerDown(){
		yield return new WaitForSeconds(7);
		speed = 5.0f;
	}

	public IEnumerator shieldOff(){
		yield return new WaitForSeconds(7);
		shieldOn = false;
	}


}