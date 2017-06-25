using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour {
	public MyButton closeButton;
	public MyButton repeatButton;
	public MyButton menuButton;
	public MyButton background;
	public List<Sprite> crystalsImages;
	public List<UI2DSprite> crystals;
	AudioSource loseSource;
	public AudioClip loseSound;

	// Use this for initialization
	void Start () {
		if (Girl.copy_girl!=null) Girl.copy_girl.setCanMove (false);
		if (LevelController.getSound ()) {
			loseSource = gameObject.AddComponent<AudioSource> ();
			loseSource.clip = loseSound;
			loseSource.Play ();
		}
		closeButton.signalOnClick.AddListener (this.OnCloseBtnAndBackground);
		background.signalOnClick.AddListener (this.OnCloseBtnAndBackground);
		//Тут я переплутала префаби, тобто menuButton насправді - repeatButton і навпаки;
		menuButton.signalOnClick.AddListener (this.OnRepeatBtn);
		repeatButton.signalOnClick.AddListener (this.OnCloseBtnAndBackground);

	}
	public void OnCloseBtnAndBackground() {
		StartCoroutine(LevelController.levelController.openIntroScene());
	}

	public void OnRepeatBtn() {
		StartCoroutine(LevelController.levelController.repeatLevel());
	}

	// Update is called once per frame
	void Update () {
		
	}
}
