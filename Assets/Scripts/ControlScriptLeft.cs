using UnityEngine;
using System.Collections;
using System;

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
	public float jumpBuffer = 0.1f; //Amount of time user can hold down the jump key before landing to initiate another jump.
	float timeTrack;
	bool jumpBufferEnable = false;
	bool bufferCanBeEnabled = true;
	float jumpBufferDifference = 0;


	void Start () {
		anim = GetComponent<Animator>();

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
		Debug.Log (jumpBufferDifference);
		if (!SceneControls.controller.paused) {
			if(Input.GetKeyDown (KeyCode.W)) {
				if (grounded) {
					Jump ();
					bufferCanBeEnabled = false;
				} else {
					if (bufferCanBeEnabled) {
						timeTrack = Time.time;
						jumpBufferEnable = true;
						bufferCanBeEnabled = false;
					}
				}
			} else if (Input.GetKey (KeyCode.W) && grounded) {
				if (jumpBufferEnable) {
					jumpBufferDifference = Time.time - timeTrack;
					if (jumpBufferDifference < jumpBuffer) {
						Jump ();
					} else {
						bufferCanBeEnabled = false;
						jumpBufferEnable = false;
					}
				} 
			}
			if(Input.GetKeyUp (KeyCode.W)) {
				jumpBufferEnable = false;
				bufferCanBeEnabled = true;
			}
		}
	}

	void Jump() {
		anim.SetBool("Ground", false);
		rigidbody2D.AddForce (new Vector2(0, jumpForce));
		jumpBufferEnable = false;
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
