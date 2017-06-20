using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour {

	public Wall wall1, wall2, wall3;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();
		if (girl != null && LevelController.levelController.getHasKey()) {
			Boy.copy_boy.giveFreedom ();
				destroyWalls ();
		}
	}

	void destroyWalls() {
		wall1.destroyWall ();
		wall2.destroyWall ();
		wall3.destroyWall ();
	}
}
