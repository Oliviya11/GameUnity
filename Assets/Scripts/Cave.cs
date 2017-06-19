using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour {
	public Rotator rotator;
	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {

	
	}
	void OnTriggerStay2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();

		if (girl != null) {
			//while (!Girl.copy_girl.comeInCave())
			Debug.Log("Inside");
		//	  rotator.setRotating (true);

		}
	}
}
