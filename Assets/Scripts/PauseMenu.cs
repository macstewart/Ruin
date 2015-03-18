using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public static PauseMenu menu;

	void Awake () {
		if (menu == null) {
			DontDestroyOnLoad(gameObject);
			menu = this;
			menu.gameObject.SetActive(true);
		} else if (menu != this) {
			Destroy(gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevelName == "StartMenu")
			Destroy (gameObject);
	
	}

}
