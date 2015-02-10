using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {

	public int blockRange = 5;
	public float speed = 2f;
	public float returnDelay;
	public bool vertical;
	public bool flipMovement;

	const float BLOCK_WIDTH = 0.32f;
	float currentSpeed;
	float range;

	void Awake () {
		range = blockRange*BLOCK_WIDTH;
		if (flipMovement)
			currentSpeed = -speed;
		else 
			currentSpeed = speed;


	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!vertical) {
		} else {

		}
	
	}
}
