using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : Collectable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override void OnGirlHit (Girl girl)
	{
		LevelController.levelController.increaseCandleNumber ();
	}
}
