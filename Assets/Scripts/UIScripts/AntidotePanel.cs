using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntidotePanel : MonoBehaviour {

	public UILabel label;

	// Update is called once per frame
	void FixedUpdate () {
		label.text = LevelController.levelController.getAntidoteNumber ().ToString ();
	}
}
