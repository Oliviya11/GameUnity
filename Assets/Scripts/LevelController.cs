using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
	int attempt = 0;
	public static LevelController levelController;
	public float timeOfCandlesBurning;
	public float extinguishTime, afterDeathTime;
	public CandleBackground candle_background;
	public GameObject losePrefab;
	static bool music, sound;

	float cur_time, main_time;
	bool hasKey = false;
	int antidote_number=0;
	int bomb_number=0;
	int candle_number=0;
	// Use this for initialization
	void Awake () {
		levelController = this;
		setInfo ();
		Time.timeScale = 1;
		increaseCandleNumber ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		main_time = Time.timeSinceLevelLoad;
		if (Girl.copy_girl!=null &&!Girl.copy_girl.isDead())
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
		if (antidote_number > 0) bomb_number--;
	}

	public bool hasBombs() {
		return bomb_number != 0;
	}

	public void increaseCandleNumber() {
		candle_number++;
	}

	void decreaseCandleNumber() {
		
		if (main_time - cur_time > timeOfCandlesBurning && candle_number > 0) {
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
			Girl.copy_girl.setDead (true);
		}
	}



	public void onGirlDeath(Girl girl){
		StartCoroutine (openLosePanel());
	}

	public IEnumerator openLosePanel() {
		yield return new WaitForSeconds (afterDeathTime);
		Girl.copy_girl.setDead (false);
		Girl.copy_girl.setCanMove (true);
		Girl.copy_girl.muteBackgroundMusic ();
		//Знайти батьківський елемент
		GameObject parent = UICamera.first.transform.parent.gameObject;
		//Створити Prefab
		GameObject obj = NGUITools.AddChild (parent, losePrefab);
		//Отримати доступ до компоненту (щоб передати параметри)
		obj.GetComponent<LosePanel>();
		Time.timeScale = 0;
	}

	public IEnumerator repeatLevel() {
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Level1");
	}



	public int getCandleNumber() {
		return candle_number;
	}

	public int getBombNumber() {
		return bomb_number;
	}

	public int getAntidoteNumber() {
		return antidote_number;
	}

	public bool getIfHasKey() {
		return hasKey;
	}
	public static void setMusic(bool val) {
		music = val;
	}
	public static void setSound(bool val) {
		sound = val;
	}

	public static bool getMusic() {
		return music;
	}
	public static bool getSound() {
		return sound;
	}

	public void writeMusic() {
		MusicAndSound newMusicAndSound = new MusicAndSound ();
		newMusicAndSound.sound = sound;
		newMusicAndSound.music = music;
		string str2 = JsonUtility.ToJson (newMusicAndSound);
		PlayerPrefs.SetString ("MusicAndSound", str2);
	}

	public void save() {
		PlayerPrefs.Save ();
	}

	public void setInfo() {
		string str2 = PlayerPrefs.GetString ("MusicAndSound", null);
		MusicAndSound musicAndSound = JsonUtility.FromJson<MusicAndSound> (str2);
	
		if (musicAndSound != null) {
			music = musicAndSound.music;
			sound = musicAndSound.sound;
		}
	}

	public IEnumerator openIntroScene() {
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("IntroScene");
	}


}
