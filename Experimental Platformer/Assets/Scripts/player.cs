using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	public UIManager uiManagerScript;
	public GameManager gameManagerScript;
	//[HideInInspector] 
	public bool facingRight = true;
	//[HideInInspector] 
	public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 20f;
	public Transform groundCheck;

	public bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	public AudioSource jumpSound;
	//public AudioSource life;

	public Vector3 spawn;

	// Use this for initialization
	void Awake () 
	{
		uiManagerScript = GameObject.Find("Canvas").GetComponent<UIManager>();
		gameManagerScript = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		spawn = new Vector3 (0, 0, 0);
	}

	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));



		transform.rotation = Quaternion.Euler (0, 0, 0);

		if (grounded) {
			anim.SetBool ("jump", false);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)&& grounded)
		{
			jump = true;
			Debug.Log ("jump");
		}
		if (transform.position.y < -10) {
			uiManagerScript.MinusLives ();
			transform.position = spawn;
		}
		if (uiManagerScript.lives <= 0) {
			gameManagerScript.gameOver = true;
			Destroy (gameObject);
		}

	}

	void FixedUpdate()
	{

		float h = Input.GetAxis("Horizontal");

		//anim.SetFloat("Speed", Mathf.Abs(h));

		if(h != 0){
			anim.SetBool ("Running", true);
		}else{
			anim.SetBool("Running" ,false);
		}

		if (h * rb2d.velocity.x < maxSpeed && transform.position.x >= -8)
			rb2d.AddForce(Vector2.right * h * moveForce);

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();

		if (jump)
		{
			anim.SetBool("jump" , true);
			rb2d.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
			jumpSound.Play();
			jump = false;
		}
		if (transform.position.x <= -8) {
			rb2d.velocity = new Vector2 (1, rb2d.velocity.y);
		}
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.name.Contains ("spawnpoint")) {
			spawn = other.transform.position;
		} else if (other.name.Contains ("Fireball")) {
			uiManagerScript.MinusLives ();
			transform.position = spawn;
		} else if (other.name.Contains ("lava")) {
			uiManagerScript.MinusLives ();
			transform.position = spawn;
		} else if (other.name.Contains("life")){
			uiManagerScript.UpdateLives();
			//life.Play();
			Destroy (other.gameObject);
		}else if(other.name.Contains("finish")){
			gameManagerScript.gameOver = true;
			Destroy (gameObject);
		}
	}

}
