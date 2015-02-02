using UnityEngine;
using System.Collections;

public class ControlScriptLeft : MonoBehaviour {

	public float maxSpeed = 5f;
	bool facingRight = true;
	Animator anim;
	SpriteRenderer rend;
	bool grounded = false;
	public Transform groundedCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 550f;


	void Start () {
		anim = GetComponent<Animator>();
		rend = GetComponent<SpriteRenderer>();

	}
	

	void FixedUpdate () {


		grounded = Physics2D.OverlapCircle(groundedCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);


		float move = Input.GetAxis ("HorizontalLeft");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);

		if(move > 0 && !facingRight || move < 0 && facingRight) 
			Flip ();
	}

	void Update() {

		if(grounded && Input.GetKeyDown (KeyCode.W) && !SceneControls.controller.paused) {
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce (new Vector2(0, jumpForce));
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
