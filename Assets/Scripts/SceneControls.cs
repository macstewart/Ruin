using UnityEngine;
using System.Collections;

public class SceneControls : MonoBehaviour {

	public static SceneControls controller; //Self referencing; used for singleton behavior (is null if object doesn't already exists)
	public bool paused = false; //Pause toggle. When true, disables movement and time, and opens pause menu
	public bool enablePause = true;
	GameObject pauseMenu;	//Pause menu gameobject reference
	GameObject levelCompleteMenu;

	float accumuScore = 0;
	
	void Awake () { //Gives the object singleton-like behavior, keeping exactly one instance on screen at once.
		if (controller == null) {
			DontDestroyOnLoad(gameObject);
			controller = this;
		} else if (controller != this) {
			Destroy(this);
		}

	}
	void Start () {
		GetPauseMenu();
		levelCompleteMenu = GameObject.Find ("LevelCompleteMenu");
		levelCompleteMenu.SetActive(false);
		SetPause(false);
	}

	void Update () {
		if (Application.loadedLevelName == "StartMenu") //Destroys controller if moving back to main menu.
			Destroy (gameObject);
		if (pauseMenu == null) { //Safety to avoid null pointers on scene loads (may be redundant now)
			GetPauseMenu();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			ResetScene();
		}
		if (Input.GetKeyDown (KeyCode.P)) { //Toggles pause
			SetPause (!paused);
		}
	
	}

	void SetPause(bool newPauseStatus) {
		if (enablePause) {
			paused = newPauseStatus;
			if (paused) {
				Time.timeScale = 0;
				pauseMenu.SetActive (true);
			} else {
				Time.timeScale = 1;
				pauseMenu.SetActive(false);
			}
		}
	}

	void GetPauseMenu() { //Finds the pause menu and sets it to disabled (for new scene load, for example);
		pauseMenu = GameObject.Find ("PauseMenu");
		pauseMenu.SetActive(false);
	}

	void GetCompleteMenu() {
		levelCompleteMenu = GameObject.Find ("LevelCompleteMenu");
	//	levelCompleteMenu.SetActive(false);
	}

	public void ResetScene() { //Reload current scene and disables the pause if the game was when the reset command was given
		Application.LoadLevel (Application.loadedLevelName);
		SetPause(false);
		enablePause = true;
	}

	public void CalcScore(float endTime){

		accumuScore += endTime;
		Debug.Log (accumuScore);
	}
}
