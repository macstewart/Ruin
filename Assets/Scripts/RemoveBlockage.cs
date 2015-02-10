using UnityEngine;
using System.Collections;

public class RemoveBlockage : MonoBehaviour {

	public GameObject target;
	float timeSinceLastCollision = 0;
	public float delayTime;
	bool collision = false;

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			target.SetActive(false);
			collision = true;

		}
	}
	void Update (){

		if (collision) {
			timeSinceLastCollision += Time.deltaTime;  
			if (timeSinceLastCollision > delayTime) {
				target.SetActive (true);
					timeSinceLastCollision = 0;
			}
		}
	}
}
