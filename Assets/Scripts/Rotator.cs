using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	//int counter=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
			Quaternion rotationY = Quaternion.AngleAxis (1, Vector3.up);
			transform.rotation *= rotationY;
		
	}
}
