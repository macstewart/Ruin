using UnityEngine;
using System.Collections;

public class DynamicMenuCamera : MonoBehaviour {

	Rect screenRect;
	
	// Use this for initialization
	void Start () {
		screenRect = new Rect (0,0, Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if (screenRect.Contains(Input.mousePosition))
			transform.position = new Vector3((Input.mousePosition.x - Screen.width/2)/500, (Input.mousePosition.y - Screen.height/2)/500, transform.position.z);
	}
}
