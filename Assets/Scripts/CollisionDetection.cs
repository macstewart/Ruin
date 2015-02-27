using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	

	private Vector3 startPosRight;
	private Vector3 startPosLeft;
	
	void Start(){
		startPosRight = GameObject.Find("RightPlayer").transform.position;
		startPosLeft = GameObject.Find("LeftPlayer").transform.position;
	}
	
	
	// Resets the current scene if the right or left player comes in contact with this object (use for simple hazards)
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			//Application.LoadLevel(Application.loadedLevelName);

			respawn();
			
		}
		
	}
	
	void respawn(){
		
		GameObject.Find("RightPlayer").transform.position = startPosRight;
		GameObject.Find("LeftPlayer").transform.position = startPosLeft;
		
		
	}
}
