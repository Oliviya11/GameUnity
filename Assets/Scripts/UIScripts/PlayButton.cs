using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	void Start () {
		this.GetComponent<MyButton>().signalOnClick.AddListener (this.loadPreview);
	}

	void loadPreview() {
		SceneManager.LoadScene ("Preview");
	}

}
