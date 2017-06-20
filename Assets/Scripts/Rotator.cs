using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	int counter=0;
	// Use this for initialization
	bool rotating = false;
	bool rotatingCompleted = false;
	bool canMoveInCave = false;
	bool front = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (rotating)
			rotate ();
	}

	void rotate() {
		if (counter <= 180) {
			Quaternion rotationY = Quaternion.AngleAxis (1, Vector3.up);
			transform.rotation *= rotationY;
		}
		if (counter == 180 && front ) {
			rotatingCompleted = true;
		} 
		if (!front) {
			rotatingCompleted = false;
		
		}
		if (counter == 180)
			canMoveInCave = true;

	    
		counter++;
	}

	public void rotateSide() {
		rotating = true;
		counter = 0;
		changeFront ();
	}
	/*
	public void notRotateSide() {
		rotating = false;
	}
	*/
	public bool isRotated() {
		return rotatingCompleted;
	}

	public bool changeFront() {
		if (front)
			front = false;
		else
			front = true;
		return front;
	}

	public bool getCanMoveInCave() {
		return canMoveInCave;
	}

	public void setCanMoveInCave(bool val) {
		canMoveInCave = val;
	}
}

