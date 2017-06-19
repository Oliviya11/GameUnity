using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antidote : Collectable {

	protected override void OnGirlHit (Girl girl)
	{
		LevelController.levelController.increaseAntidoteNumber ();
	}
}
