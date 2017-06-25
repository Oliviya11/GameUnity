using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour {
	public MyButton nextButton;
	public MyButton background;
	public MyButton closeButton;
	AudioSource winSource;
	public AudioClip winSound;


	// Use this for initialization
	void Start () {
//		HeroRabbit.rabbit_copy.setCanMove (false);
		if (LevelController.getSound ()) {
			winSource = gameObject.AddComponent<AudioSource> ();
			winSource.clip = winSound;
			winSource.Play ();
		}
		closeButton.signalOnClick.AddListener (this.OnCloseBtnAndBackground);
		background.signalOnClick.AddListener (this.OnCloseBtnAndBackground);
		nextButton.signalOnClick.AddListener (this.OnCloseBtnAndBackground);
	}


	public void OnCloseBtnAndBackground() {
		LevelController.levelController.openIntroScene();
	}



}
