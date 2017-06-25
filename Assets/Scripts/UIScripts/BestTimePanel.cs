using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTimePanel : MonoBehaviour {

	public UILabel label;

	// Update is called once per frame
	void FixedUpdate () {

		float time = PlayerPrefs.GetFloat ("bestTime");
		label.text ="Best time: "+ time.ToString ()+" (m)";

	}
}
