using UnityEngine;
using System.Collections;

public class SceneLoader: MonoBehaviour {
	
	public void loadScene(string scene) { //Loads the scene with the name given
		Application.LoadLevel(scene);
	}
}
