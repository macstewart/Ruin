using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	public GameObject target;
	public float delayTime;

	private float timeSinceLastCollision = 0;
	private bool collision = false;

	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("Enter");
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			this.renderer.enabled = false;
			target.SetActive(false);
			collision = true;
			timeSinceLastCollision = 0;
		}
	}



	void OnTriggerExit2D(Collider2D col) {
		Debug.Log ("Exit");
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			collision = false;

		}
	}
	

	void Update (){
		if (!collision) {
			timeSinceLastCollision += Time.deltaTime;  
			if (timeSinceLastCollision > delayTime) {
				this.renderer.enabled = true;
				target.SetActive(true);
				timeSinceLastCollision = 0;
			}
		}

	}
}