using UnityEngine;
using System.Collections;

public class SceneLoader: MonoBehaviour {

	CompleteMenu completeMenu;
	int finalSceneIndex = 7;
	
	public void loadScene(string scene) { //Loads the scene with the name given
		if (scene == "StartMenu")
			Destroy(gameObject.GetComponent<SceneControls>().pauseMenu);
		Application.LoadLevel(scene);
	}

	public void loadNextScene() {
		if (Application.loadedLevel < finalSceneIndex) {
			if (gameObject != null && gameObject.GetComponent<SceneControls>() != null) {
				gameObject.GetComponent<SceneControls>().enablePause = true;
				gameObject.GetComponent<SceneControls>().paused = false;
			}
			Application.LoadLevel (Application.loadedLevel + 1);
		} else {
			Debug.Log ("LOADING MENU");
			Debug.Log (Application.loadedLevel);
			Application.LoadLevel (0);
		}
	}

}
