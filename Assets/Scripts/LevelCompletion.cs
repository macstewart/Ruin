using UnityEngine;
using System.Collections;

public class LevelCompletion : MonoBehaviour {

	GameObject player;
	public GameObject LevelCompleteMenu;
	Timer timerScript;

	void Start(){
		player = GameObject.Find("LeftPlayer");

		timerScript = player.GetComponent<Timer>();
	}
	// Resets the current scene if the right or left player comes in contact with this object (use for simple hazards)
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.name=="RightPlayer"){
			timerScript.rightPlayerCompletion = true;
			Debug.Log ("collision");

			if (timerScript.leftPlayerCompletion == true){
				timerScript.EndTimer();
				LevelCompleteMenu.SetActive(true);
				GameObject.Find ("SceneController").GetComponent<SceneControls>().enablePause = false;
			}
		}

		if (col.gameObject.name=="LeftPlayer"){
			timerScript.leftPlayerCompletion = true;

			if (timerScript.rightPlayerCompletion == true){
				timerScript.EndTimer();
				LevelCompleteMenu.SetActive(true);
				GameObject.Find ("SceneController").GetComponent<SceneControls>().enablePause = false;
			}
			
		}
		
	}
}
