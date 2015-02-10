using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public GameObject target;
	float timeSinceLastCollision = 0;
	public float delayTime;
	bool collision = false;
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			transform.localScale = new Vector3(1f, -1.5f, 1f);
			target.renderer.enabled = false;
			target.collider2D.enabled = false;
			collision = true;
			timeSinceLastCollision = 0;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			collision = false;
		}

	}
	

	void Update (){
		
		if (!collision) {
			timeSinceLastCollision += Time.deltaTime;  
			if (timeSinceLastCollision > delayTime) {
				transform.localScale = new Vector3(1f, -1f, 1f);
				target.renderer.enabled = true;
				target.collider2D.enabled = true;
				timeSinceLastCollision = 0;
			}
		}

	}
}