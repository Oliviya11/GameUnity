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
//		HeroRabbit.rabbit_copy.setCanMove (false);
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
	public void 	OnCloseBtnAndBackground() {
		//StartCoroutine(LevelController.current.openMenu());
	}

	public void OnRepeatBtn() {
		//StartCoroutine(LevelController.current.openLevel());
	}

	// Update is called once per frame
	void Update () {
		
	}
}
