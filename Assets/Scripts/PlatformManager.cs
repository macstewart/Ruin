using UnityEngine;
using System.Collections;

public enum PlatformType{
	middle,edge,wall
}

public class PlatformManager : MonoBehaviour {

	public PlatformType type = PlatformType.wall;	//Platform type enum used to texture and place hitboxes. Defaults to wall (no friction boxes)
	public bool textureOverride = false;	//Toggle that allows dev to set custom texture for individual blocks
	public bool rightSideEdge = false;		//Set whether platform is on the left or right side. Flips texture and hitboxes if true
	public BoxCollider2D edge, innerEdge, floor, wall;	//Self referencing box colliders. For toggling indivual colliders
	SpriteRenderer spriteRend;		//Self referencing. Used to change sprite(texture) on the fly
	Sprite[] sprites;	//Container for sprites to allow loading other textures on the fly

	// Use this for initialization
	void Awake () {
		sprites = Resources.LoadAll<Sprite>("Sprites/Platforms/goodly-2x");
		spriteRend = GetComponent<SpriteRenderer>();
		switch (type){				
		case PlatformType.middle: //If middle platform, load middle texture and set full friction hitbox
			if (!textureOverride)
				spriteRend.sprite = sprites[29];
			floor.enabled = true;
			break;
		case PlatformType.edge:		//If edge, set no friction outer side and full friction top, flip texture if necessary
			if (!textureOverride)
				spriteRend.sprite = sprites[28];
			edge.enabled = true;
			innerEdge.enabled = true;
			if (rightSideEdge)
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			break;
		case PlatformType.wall:		//If wall, set no friction hitbox. Flip texture if necessary
			if (!textureOverride)
				spriteRend.sprite = sprites[43];
			if (rightSideEdge)
				transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
			wall.enabled = true;
			break;
		}
	}
}
