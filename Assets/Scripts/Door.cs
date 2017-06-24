using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {

		Girl girl = collider.GetComponent<Girl> ();
	
		if (girl != null && !girl.isDead() && !Boy.copy_boy.isDead() && !girl.isHidden() && girl.getIsFreeBoy()) {
			SceneManager.LoadScene ("WinScene");
		}
	}
}
