using UnityEngine;
using System.Collections;

public class RemoveBlockage : MonoBehaviour {

	public GameObject target;
	float timeSinceLastCollision = 0;
	public float delayTime;
	bool collision = false;

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			target.renderer.enabled = false;
			target.collider2D.enabled = false;
			collision = true;

		}
	}

	void Update (){

		if (collision) {
			Debug.Log ("hit");
			timeSinceLastCollision += Time.deltaTime;  
			if (timeSinceLastCollision > delayTime) {
					target.renderer.enabled = true;
					target.collider2D.enabled = true;
					timeSinceLastCollision = 0;
			}
		}
	}
}
