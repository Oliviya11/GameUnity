using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public static LevelController levelController;
	public float timeOfCandlesBurning;
	public float extinguishTime;
	public CandleBackground candle_background;

	float cur_time = 0;
	bool hasKey = false;
	int antidote_number=0;
	int bomb_number=0;
	int candle_number=1;
	// Use this for initialization
	void Start () {
		levelController = this;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		decreaseCandleNumber ();
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

	public void increaseCandleNumber() {
		candle_number++;
	}

	void decreaseCandleNumber() {
		if (Time.time - cur_time > timeOfCandlesBurning && candle_number > 0) {
			candle_number--;
			StartCoroutine (extinguishCandle ());
			cur_time = Time.time;
		}
	}

	IEnumerator extinguishCandle() {
		for (int i=0; i<3; ++i) {
		   candle_background.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.8f);
		   yield return new WaitForSeconds (extinguishTime);
		   candle_background.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0f);
		   yield return new WaitForSeconds (extinguishTime);
		}

		if (candle_number == 0) {
			yield return new WaitForSeconds (extinguishTime);
			candle_background.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.95f);
		}
	}

}
