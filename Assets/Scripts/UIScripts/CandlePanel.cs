using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandlePanel : MonoBehaviour {
	public UILabel label;

	// Update is called once per frame
	void FixedUpdate () {
		label.text = LevelController.levelController.getCandleNumber ().ToString ();
	}
}
