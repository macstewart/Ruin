using UnityEngine;
using System.Collections;

public class RemoveBlockage : MonoBehaviour {

	public GameObject target;

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer" | col.gameObject.name=="LeftPlayer"){
			Destroy(target);

		}
		
	}
}
