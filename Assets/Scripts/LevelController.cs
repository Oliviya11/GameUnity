using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController levelController;
	bool hasKey = false;
	int antidote_number=0;
	int bomb_number=0;
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

	public void setHasKey(bool val) {
		hasKey = val;
	}

	public bool getHasKey() {
		return hasKey;
	}

	public void increaseBombNumber() {
		bomb_number++;
	}

	public void decreaseBombNumber() {
		if (antidote_number > 0) antidote_number--;
	}

	public bool hasBombs() {
		return bomb_number != 0;
	}
}
