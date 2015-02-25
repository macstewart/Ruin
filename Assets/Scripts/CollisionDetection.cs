using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {


	// Resets the current scene if the right or left player comes in contact with this object (use for simple hazards)
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			Application.LoadLevel(Application.loadedLevelName);

		}
		
	}
}
