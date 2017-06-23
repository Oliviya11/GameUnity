using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Hollow : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		ColorHuman human = collider.GetComponent<ColorHuman> ();
		ColorBoy boy = collider.GetComponent<ColorBoy> ();
		ColorGirl girl = collider.GetComponent<ColorGirl> ();
		if (boy != null) 
			StartCoroutine(ColorGirl.copy_girl.waitAndRun());
		if (girl != null)
			SceneManager.LoadScene ("Level1");
		if (human != null ) {
			human.destroyHuman ();
		}
       
	}


}
