using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	private float newTime=0;
	private float endTime;

	public bool leftPlayerCompletion = false;
	public bool rightPlayerCompletion = false;
	

	void Start(){
		InvokeRepeating( "IncreaseTime", 0.1f, 0.1f);
	}


	void IncreaseTime(){
		newTime = Mathf.Round((newTime + 0.1f)*100.0f) / 100.0f;
	}

	void OnGUI() {
		GUI.Label(new Rect(10,10,400,90), "Timer = " + newTime.ToString () + " Seconds");

	}

	public void EndTimer(){
		endTime = Mathf.Round(newTime *100.0f) / 100.0f;;
		CancelInvoke (); //cancles invokeRepeating
		Debug.Log (endTime);
	}
}
