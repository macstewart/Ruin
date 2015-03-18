using UnityEngine;
using System.Collections;

public class CompleteMenu : MonoBehaviour {

	GameObject sceneControls;

	void Awake () {
		sceneControls = GameObject.Find ("SceneController");
		sceneControls.GetComponent<SceneControls>().setCompleteMenu(gameObject);
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "StartMenu")
			Destroy (gameObject);
	
	}

}
