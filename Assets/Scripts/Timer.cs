using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float startTime;
	private float newTime;
	private float endTime;

	public bool leftPlayerCompletion = false;
	public bool rightPlayerCompletion = false;
	

	void Awake(){
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		newTime = Time.time - startTime;
		//Debug.Log(newTime);
	}

	public void EndTimer(){
		endTime =Time.time -  startTime;
		Debug.Log (endTime);
	}
}
