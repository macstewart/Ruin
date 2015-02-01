using UnityEngine;
using System.Collections;

public class SceneControls : MonoBehaviour {

	public static SceneControls controller;
	public bool paused = false;
	
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
			if (!paused){
				Time.timeScale = 0;
				paused = true;
			} else {
				Time.timeScale = 1;
				paused = false;
			}
		}
	
	}
}
