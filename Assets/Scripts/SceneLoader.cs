using UnityEngine;
using System.Collections;

public class SceneLoader: MonoBehaviour {

	public CompleteMenu completeMenu;
	public int finalSceneIndex = 4;
	
	public void loadScene(string scene) { //Loads the scene with the name given
		Application.LoadLevel(scene);
	}

	public void loadNextScene() {
		if (Application.loadedLevel < finalSceneIndex) {
			Application.LoadLevel (Application.loadedLevel + 1);
		} else {
			Application.LoadLevel (0);
		}
	}

}
