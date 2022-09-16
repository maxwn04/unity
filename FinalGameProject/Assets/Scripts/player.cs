using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

	public AudioSource walkSound;
	public AudioSource jumpSound;
	public AudioSource teleportSound;
	public AudioSource deathSound;

	public GameObject transition;

	public float spawnX;
	public float spawnY;

	public UIManager uiManagerScript;
	//public GameManager gameManagerScript;
	//[HideInInspector] 
	public bool facingRight = true;
	//[HideInInspector] 
	public float speed = 6f;

	public bool dead = false;
	//public float jumpForce = 20f;

	public Transform groundCheck;
	public Transform groundCheck2;


	public bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private SpriteRenderer sprite;

	//jumpVars
	public bool jump = false;
	public float maxJumpVelocity = 13f;
	public float minJumpVelocity = 6f;
	//public AudioSource life;

	public bool teleport = false;
	public Vector3 movement;
	public int teletTime = 75;
	public bool canTeleport = true;
	public GameObject imagePrefab;
	public float teletspeed = 4f;
	public int teleportedFor = 0;

	public Vector3 spawn;

	public GameObject laserColliders;

	public bool end = false;

	// Use this for initialization
	void Awake () 
	{
		transition.SetActive(false);
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
		//gameManagerScript = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer> ();
		spawn = new Vector3 (spawnX, spawnY, 0);
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("Start");
		}
/*play death sound*/
		if (dead) {
			deathSound.Play ();
		}
/*play teleport sound*/
		if (teleport) {
			teleportSound.Play ();
		}
/*play jump sound*/
		/*if (jump) {
			jumpSound.Play ();
		}*/
		if (Physics2D.Linecast (transform.position, groundCheck.position, 1 << LayerMask.NameToLayer ("Ground")) || Physics2D.Linecast (transform.position, groundCheck2.position, 1 << LayerMask.NameToLayer ("Ground"))) {
			grounded = true;
		} else {
			grounded = false;
		}



		transform.rotation = Quaternion.Euler (0, transform.rotation.y, 0);

		if (grounded) {
			anim.SetBool ("jump", false);
		}
		if ((Input.GetKeyDown (KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && grounded && !end)
		{
			jump = true;
		jumpSound.Play ();
			Debug.Log ("jump");

		}
		if (Input.GetKeyDown (KeyCode.LeftShift) && canTeleport && !teleport && !dead && !end) {
			if (facingRight) {
				Instantiate (imagePrefab, transform.position, Quaternion.identity);
			} else {
				Instantiate (imagePrefab, transform.position, Quaternion.Euler (new Vector3 (0, 180, 0)));
			}
			rb2d.gravityScale = 0;
			canTeleport = false;
			teleport = true;
			movement = new Vector3 (rb2d.velocity.x, rb2d.velocity.y, 0);
			anim.SetBool ("telet", true);
		} else if (Input.GetKeyDown (KeyCode.LeftShift) && teleport) {
			teleport = false;
			rb2d.velocity = movement;
			rb2d.gravityScale = 3;
			anim.SetBool ("telet", false);
			teleportedFor = 0;
			StartCoroutine (cooldown());

		}
		/*
		if (transform.position.y < -10) {
			transform.position = spawn;
			GameManager.instance.die ();
		}*/

		if (teleport) {
			laserColliders.SetActive (false);
		} else {
			laserColliders.SetActive (true);
		}
	}

	void FixedUpdate()
	{

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if (end) {
			h = 0;
			v = 0;
		}
		if (h > 0 && !facingRight) {
			Flip ();
		} else if (h < 0 && facingRight) {
			Flip ();
		}
		if (teleportedFor >= teletTime) {
			teleport = false;
			rb2d.velocity = movement;
			rb2d.gravityScale = 3;
			anim.SetBool ("telet", false);
			teleportedFor = 0;
			StartCoroutine (cooldown());
		}
		if (teleport && !dead && !end) {
			if (h != 0 || v != 0) {
				teleportedFor++;
			}
			rb2d.velocity = new Vector3(0,0,0);
			transform.Translate(new Vector3(1*h, 1*v,0)*Time.deltaTime * teletspeed);

		} else if (!dead) {
			

			//anim.SetFloat("Speed", Mathf.Abs(h));

			rb2d.velocity = new Vector2 (speed * h, rb2d.velocity.y);
			if (h != 0) {
				anim.SetBool ("Running", true);
/*play walk sound*/
				walkSound.Play ();
			} else {
				anim.SetBool ("Running", false);
			}

			if (jump) {
				anim.SetBool ("jump", true);

				//rb2d.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
				rb2d.velocity = new Vector2 (0, maxJumpVelocity);
				jump = false;
			}
			if (rb2d.velocity.y > minJumpVelocity &&
			   (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp (KeyCode.UpArrow))) {
				rb2d.velocity = new Vector2 (0, minJumpVelocity);
			}



		}
	}


	public void Flip()
	{
		facingRight = !facingRight;
		/*
		Vector3 theScale = transform.localScale;
		theScale.x *= -1f;
		transform.localScale = theScale;
		*/
		Debug.Log ("flip");

		if (facingRight) {
			sprite.flipX = false;
		} else {
			sprite.flipX = true;
		}

		//sprite.flipX = true;
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Contains ("death") && !teleport) {
			dead = true;
			//deathSound.Play ();
			anim.SetBool ("dead", true);
			rb2d.gravityScale = 0;
			rb2d.velocity = new Vector3 (0, 0, 0);
			teleport = false;
			anim.SetBool ("telet", false);
			teleportedFor = 0;
			StartCoroutine (death ());
		} else if (other.tag.Equals ("jammer")) {
			if (teleport) {
				teleport = false;
				rb2d.velocity = movement;
				rb2d.gravityScale = 3;
				anim.SetBool ("telet", false);
				teleportedFor = 0;
			}

			//StartCoroutine (cooldown ());
			canTeleport = false;
		} else if (other.tag.Contains ("finish")) {
			transition.SetActive (true);
			StartCoroutine (transitionTime ());
		} else if (other.tag.Contains ("spring")) {
			anim.SetBool ("jump", true);
		} else if (other.tag.Contains ("spawn")) {
			spawn = transform.position;
		} else if (other.tag.Contains ("refill") && teleport) {
			teleportedFor = 0;
			Destroy (other.gameObject);
		} else if (other.tag.Contains ("disc")) {
			
			Destroy (other.gameObject);
		} else if (other.name.Equals ("End")) {
			end = true;
			StartCoroutine (startEnd());
		}

	}
	public void OnTriggerExit2D(Collider2D other){
		if (other.tag.Equals ("jammer")) {
			canTeleport = true;
		}
	}
	/*
	public IEnumerator teleportTime(){
		yield return new WaitForSeconds (10);
		teleport = false;
		rb2d.velocity = movement;
		rb2d.gravityScale = 3;
		anim.SetBool ("telet", false);
		teleportedFor = 0;
		StartCoroutine (cooldown());
	}
	*/
	public IEnumerator cooldown(){
		yield return new WaitForSeconds (1f);
		canTeleport = true;
	}
	public IEnumerator death(){
		yield return new WaitForSeconds (.75f);
		GameManager.instance.die ();
		transform.position = spawn;
		rb2d.gravityScale = 3;
		anim.SetBool ("dead", false);
		dead = false;
	}
	public IEnumerator transitionTime(){
		yield return new WaitForSeconds (.5f);
		GameManager.instance.IncreaseLevel ();
	}
	public IEnumerator startEnd(){
		yield return new WaitForSeconds (2f);
		if (facingRight) {
			Flip ();
		}
		yield return new WaitForSeconds (4f);
		transition.SetActive (true);
		yield return new WaitForSeconds (1f);
		GameManager.instance.Reset ();
		uiManagerScript.theEnd ();
		yield return new WaitForSeconds (4f);
		//uiManagerScript.theEndReset ();

		//SceneManager.LoadScene ("Start");
	}
		
}
