using UnityEngine;
using System.Collections;

public class CompleteMenu : MonoBehaviour {

	public static CompleteMenu completeMenu;

	void Awake () {
		if (completeMenu == null) {
			DontDestroyOnLoad(gameObject);
			completeMenu = this;
			completeMenu.gameObject.SetActive(true);
		} else if (completeMenu != this) {
			Destroy(gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "StartMenu")
			Destroy (gameObject);
	
	}

}
