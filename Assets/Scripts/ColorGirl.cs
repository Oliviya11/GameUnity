using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGirl : ColorHuman {
	public float waitBeforeRunningInHollow;
	public AudioClip pianoIntroSound = null;
	AudioSource pianoSource = null;
	public static ColorGirl copy_girl;
	void Awake() {
		copy_girl = this;
		pianoSource = gameObject.AddComponent<AudioSource> ();
		pianoSource.clip = pianoIntroSound;
	}

	void playPianoIntroSound() {
		 pianoSource.Play ();
	} 

	public IEnumerator waitAndRun() {
		setCanWalk (false);
	    playPianoIntroSound();
		yield return  new WaitForSeconds (waitBeforeRunningInHollow);
		setCanWalk (true);
	}

}
