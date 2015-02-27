using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	private float startTime;
	private float newTime;

	void Awake(){
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		newTime = Time.time - startTime;
		//Debug.Log(newTime);
	}
}
