using UnityEngine;
using System.Collections;

public class SceneControls : MonoBehaviour {

	public static SceneControls controller;
	public bool paused = false;
	GameObject pauseMenu;
	
	void Awake () {
		if (controller == null) {
			DontDestroyOnLoad(gameObject);
			controller = this;
		} else if (controller != this) {
			Destroy(this);
		}

	}
	void Start () {
		GetPauseMenu();
	}
	
	void Update () {

		if (pauseMenu == null) {
			GetPauseMenu();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			ResetScene();
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			if (!paused){
				Time.timeScale = 0;
				paused = true;
				pauseMenu.SetActive(true);
			} else {
				Time.timeScale = 1;
				paused = false;
				pauseMenu.SetActive(false);
			}
		}
	
	}

	void GetPauseMenu() {
		pauseMenu = GameObject.Find ("PauseMenu");
		pauseMenu.SetActive(false);
	}

	public void ResetScene() {
		Application.LoadLevel (Application.loadedLevelName);
		if (paused) {
			Time.timeScale = 1;
			paused = false;
			pauseMenu.SetActive(false);
		}
	}
}
