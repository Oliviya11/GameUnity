using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController levelController;
	int antidote_number=0;
	// Use this for initialization
	void Start () {
		levelController = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void increaseAntidoteNumber() {
		antidote_number++;
	}

	public void decreaseAntidoteNumber() {
		if (antidote_number > 0) antidote_number--;
	}

	public bool hasAntidote() {

		return antidote_number != 0;
	}
}
