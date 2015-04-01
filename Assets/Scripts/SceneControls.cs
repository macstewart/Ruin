using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneControls : MonoBehaviour {

	public static SceneControls controller; //Self referencing; used for singleton behavior (is null if object doesn't already exists)
	public bool paused = false; //Pause toggle. When true, disables movement and time, and opens pause menu
	public bool enablePause = true;
	public GameObject pauseMenu;	//Pause menu gameobject reference
	GameObject levelCompleteMenu;
	CompleteMenu completeMenuObject;
	bool newScene;

	float accumuScore = 0;
	Text score;
	Text aScore;
	
	void Awake () { //Gives the object singleton-like behavior, keeping exactly one instance on screen at once.
		if (controller == null) {
			DontDestroyOnLoad(transform.gameObject);
			controller = this;

		} else if (controller != this) {
			Destroy(gameObject);
		}



	}
	void Start () {
		GetPauseMenu();
		SetPause(false);
		enablePause = true;
		SetPause(false);
		
	}

	void Update () {
		if (Application.loadedLevelName == "StartMenu") { //Destroys controller if moving back to main menu.
			enablePause = false;
			Destroy (gameObject);
		}
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
				if (pauseMenu != null)
					pauseMenu.SetActive (true);
			} else {
				Time.timeScale = 1;
				if (pauseMenu != null)
					pauseMenu.SetActive(false);
			}
		}
	}

	void GetPauseMenu() { //Finds the pause menu and sets it to disabled (for new scene load, for example);
		pauseMenu = GameObject.Find ("PauseMenu");
		if (pauseMenu != null)
			pauseMenu.SetActive(false);
	}

	void OnLevelWasLoaded(int level) {
		SetPause(false);
		enablePause = true;
	}
	

	public void ResetScene() { //Reload current scene and disables the pause if the game was when the reset command was given
		Application.LoadLevel (Application.loadedLevelName);
		SetPause(false);
		enablePause = true;
	}

	public void setCompleteMenu(GameObject menu, Text[] scores) {
		levelCompleteMenu = menu;

		if (Application.loadedLevelName == "Level3") {
				score = scores [3];
				aScore = scores [2];
		} else {
			score = scores [4];
			aScore = scores [3];
		}

		enablePause = true;
		SetPause(false);
	}

	public void CalcScore(float endTime){


		accumuScore += endTime;
		Debug.Log (accumuScore);
		
		Debug.Log (score);
		Debug.Log (aScore);

		score.text = "Level Score: "+ endTime;
		aScore.text = "Total Score: " + accumuScore;

	}
}
