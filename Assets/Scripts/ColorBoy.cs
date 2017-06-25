using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBoy : ColorHuman {
	//public ColorBoy staticcopy_boy;

	void Awake() {
		muteOrActiveBackgroundMusic ();
	}

	public void muteOrActiveBackgroundMusic() {
		if (!LevelController.getMusic ()) {
			this.GetComponent<AudioSource> ().Stop();
		} else if (!this.GetComponent<AudioSource> ().isPlaying) {
			this.GetComponent<AudioSource> ().Play();
		}
	}
}
