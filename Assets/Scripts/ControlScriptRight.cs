using UnityEngine;
using System.Collections;
using System;

public class ControlScriptRight : MonoBehaviour {
	
	public float maxSpeed = 5f;
	float tempYVelocity;
	bool facingRight = true;
	Animator anim;
	BoxCollider2D boxCol;
	CircleCollider2D circleCol;
	bool grounded = false;
	public Transform groundedCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 550f;
	public float jumpBuffer = 0.1f; //Amount of time user can hold down the jump key before landing to initiate another jump.
	public float friction = 1f;
	float timeTrack;
	bool jumpBufferEnable = false;
	bool bufferCanBeEnabled = true;
	float jumpBufferDifference = 0;
	PhysicsMaterial2D frictionMaterial;
	PhysicsMaterial2D noFrictionMaterial;

	
	
	void Start () {
		anim = GetComponent<Animator>();
		boxCol = GetComponent<BoxCollider2D>();
		boxCol.sharedMaterial.friction = friction;
		circleCol = GetComponent<CircleCollider2D>();
		frictionMaterial = (PhysicsMaterial2D)Resources.Load("Materials/MaterialWithFriction");
		noFrictionMaterial = (PhysicsMaterial2D)Resources.Load ("Materials/MaterialWithoutFriction");

		
	}
	
	
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundedCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		
		
		float move = Input.GetAxis ("HorizontalRight");
		anim.SetFloat ("Speed", Mathf.Abs (move));
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
		if(move > 0 && !facingRight || move < 0 && facingRight) 
			Flip ();
	}
	
	void Update() {
		if (!SceneControls.controller.paused) {

			if (grounded) {
				boxCol.sharedMaterial = frictionMaterial;
				circleCol.sharedMaterial = frictionMaterial;
				boxCol.enabled = false;
				circleCol.enabled = false;
				boxCol.enabled = true;
				circleCol.enabled = true;
			} else {
				boxCol.sharedMaterial = noFrictionMaterial;
				circleCol.sharedMaterial = noFrictionMaterial;
				boxCol.enabled = false;
				circleCol.enabled = false;
				boxCol.enabled = true;
				circleCol.enabled = true;
			}

			if(Input.GetKeyDown (KeyCode.UpArrow)) {
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
			} else if (Input.GetKey (KeyCode.UpArrow) && grounded) {
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
			if(Input.GetKeyUp (KeyCode.UpArrow)) {
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
