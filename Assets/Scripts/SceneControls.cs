using UnityEngine;
using System.Collections;

public class SceneControls : MonoBehaviour {

	SceneControls controller;
	
	void Awake () {
		if (controller == null) {
			DontDestroyOnLoad(gameObject);
			controller = this;
		} else if (controller != this) {
			Destroy(this);
		}
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel (Application.loadedLevelName);
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			if (Time.timeScale != 0){
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
		}
	
	}
}
