using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {

		Girl girl = collider.GetComponent<Girl> ();
	
		if (girl != null && !girl.isDead() && !Boy.copy_boy.isDead() && !girl.isHidden() && girl.getIsFreeBoy()) {
			float time = PlayerPrefs.GetFloat ("bestTime");
			if (LevelController.levelController.getMaybeBestTime () < time) {
				LevelController.levelController.setTime ();
				LevelController.levelController.save ();
			}
			SceneManager.LoadScene ("WinScene");
		}
	}
}
