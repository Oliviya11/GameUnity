using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Collectable {

	protected override void OnGirlHit (Girl girl)
	{
		LevelController.levelController.setHasKey (true);
	}
}
