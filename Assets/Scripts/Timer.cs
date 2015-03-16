using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	//attach this script to a player gameObject

	private float newTime=0;
	private float endTime;

	public bool leftPlayerCompletion = false;
	public bool rightPlayerCompletion = false;

	SceneControls sceneControlScript;
	
	void Start(){
		InvokeRepeating( "IncreaseTime", 0.04f, 0.04f);

		GameObject controller = GameObject.Find("SceneController");
		sceneControlScript = controller.GetComponent<SceneControls>();
	}


	void IncreaseTime(){
		newTime = Mathf.Round((newTime + 0.04f)*100.0f) / 100.0f;
	}

	void OnGUI() {
		GUI.Label(new Rect(10,10,400,90), "Timer = " + newTime.ToString ());

	}

	public void EndTimer(){
		endTime = Mathf.Round(newTime *100.0f) / 100.0f;;
		CancelInvoke (); //cancles invokeRepeating
		sceneControlScript.CalcScore (endTime);

	}
}
