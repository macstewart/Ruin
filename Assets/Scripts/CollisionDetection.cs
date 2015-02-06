using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {


	// Use this for initialization
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			Debug.Log("hit me");
			Application.LoadLevel("test");

			//healthScript.health -= 1;
		}
		
	}
}
