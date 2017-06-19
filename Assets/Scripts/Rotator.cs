using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	//int counter=0;
	// Use this for initialization
	bool rotating = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (rotating)
			rotate ();
	}

	void rotate() {
		Quaternion rotationY = Quaternion.AngleAxis (1, Vector3.up);
		transform.rotation *= rotationY;
	}

	public void setRotating(bool val) {
		rotating = val;
	}
}
