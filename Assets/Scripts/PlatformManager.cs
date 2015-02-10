using UnityEngine;
using System.Collections;

public enum PlatformType{
	middle,edge,wall
}

public class PlatformManager : MonoBehaviour {

	public PlatformType type = PlatformType.wall;
	public bool textureOverride = false;
	public bool rightSideEdge = false;
	public BoxCollider2D edge, innerEdge, floor, wall;
	SpriteRenderer spriteRend;
	Sprite[] sprites;

	// Use this for initialization
	void Awake () {
		sprites = Resources.LoadAll<Sprite>("Sprites/Platforms/goodly-2x");
		spriteRend = GetComponent<SpriteRenderer>();
		switch (type){
		case PlatformType.middle: 
			if (!textureOverride)
				spriteRend.sprite = sprites[5];
			floor.enabled = true;
			break;
		case PlatformType.edge:
			if (!textureOverride)
				spriteRend.sprite = sprites[4];
			edge.enabled = true;
			innerEdge.enabled = true;
			if (rightSideEdge)
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			break;
		case PlatformType.wall:
			if (!textureOverride)
				spriteRend.sprite = sprites[7];
			if (rightSideEdge)
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			wall.enabled = true;
			break;
		}
	}
}
