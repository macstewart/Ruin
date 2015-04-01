using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EntryText : MonoBehaviour {

	public static EntryText controller;

	float fadeSpeed = 0.5f;
	Text text;
	Color color = Color.white;

	// Use this for initialization
	void Start () {

		Text[] textList =this.GetComponentsInChildren<Text> ();
		text = textList [0];
		text.color = color;

	
	}
	
	// Update is called once per frame
	void Update () {
		//float newColor = text.color.a - 0.1f;
		//text.color.a = newColor;

		color.a = text.color.a - 0.01f;
		text.color = color;

	
	}

}
