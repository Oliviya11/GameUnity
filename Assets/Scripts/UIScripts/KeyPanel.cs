using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPanel : MonoBehaviour {
	public UI2DSprite key;
	public Sprite fullKey;
	// Update is called once per frame
	void FixedUpdate () {
		if (LevelController.levelController.getIfHasKey()) key.sprite2D = fullKey;
	}
}
