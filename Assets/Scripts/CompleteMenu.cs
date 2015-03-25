using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CompleteMenu : MonoBehaviour {

	GameObject sceneControls;
	Text[] scores;



	void Awake () {
		Debug.Log (Application.loadedLevelName);
		sceneControls = GameObject.Find ("SceneController");

		scores = this.GetComponentsInChildren<Text> ();

		sceneControls.GetComponent<SceneControls>().setCompleteMenu(gameObject,scores);
		gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "StartMenu")
			Destroy (gameObject);
	
	}

	public void resetScene() {
		sceneControls.GetComponent<SceneControls>().ResetScene();
	}

	public void nextLevel() {
		sceneControls.GetComponent<SceneLoader>().loadNextScene();
	}

	public void loadMenu() {
		sceneControls.GetComponent<SceneLoader>().loadScene("startMenu");
	}

}
