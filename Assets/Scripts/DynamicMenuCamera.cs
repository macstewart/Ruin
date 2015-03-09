using UnityEngine;
using System.Collections;

public class DynamicMenuCamera : MonoBehaviour {

	public GameObject background;
	Rect screenRect;
	
	// Use this for initialization
	void Start () {
		screenRect = new Rect (0,0, Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		if (screenRect.Contains(Input.mousePosition))
			transform.position = new Vector3((Input.mousePosition.x - Screen.width/2)/500, (Input.mousePosition.y - Screen.height/2)/500, transform.position.z);
			background.transform.position = new Vector3(transform.position.x*0.8f, transform.position.y*0.8f, background.transform.position.z);
	}
}
