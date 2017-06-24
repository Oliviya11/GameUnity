using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {
	public float timeToWaitBeforeOpenning;
	public Rotator rotator;
	bool isGirlInCave = false;
	public float border_a;
	public float border_b;
	bool rotated = false;
	public List<Collectable> items;
	public List<Bomb> bombs;
	// Use this for initialization
	void Start () {

	}

	void FixedUpdate () {
		if (rotator.isRotated ()) {
			items.ForEach (setFalse);
			bombs.ForEach (setFalseBomb);
		} else { 
			items.ForEach (setTrue);
			bombs.ForEach (setTrueBomb);
		}

	}

	void setFalse(Collectable c) {
		c.setHidden (false);
	}
	void setTrue(Collectable c) {
		c.setHidden (true);
	}

	void setFalseBomb(Bomb b) {
		b.setHidden (false);
	}
	void setTrueBomb(Bomb b) {
		b.setHidden (true);
	}
	void OnTriggerEnter2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();

		if (girl != null) {
			isGirlInCave = true;
			StartCoroutine (openCave());
		}
	}
	void OnTriggerExit2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();

		if (girl != null) {
			isGirlInCave = false;
		}
	}

	public IEnumerator openCave() {
		yield return new WaitForSeconds (timeToWaitBeforeOpenning);
		if (isGirlInCave && !Girl.copy_girl.isDead() && Girl.copy_girl.getTimeOfStanding()>timeToWaitBeforeOpenning) {
			
			rotator.setCanMoveInCave (false);
			rotator.rotateSide ();
			float cur_pos = Girl.copy_girl.transform.position.x;
			if (!rotated) {
				Girl.copy_girl.setCanGoOutside (false, cur_pos - border_a, cur_pos + border_b);
			        rotated = true;
				Girl.copy_girl.setHiddenInCave (true);
     			Boy.copy_boy.setCanMoveInCave (false);
			}
			else {
				Girl.copy_girl.setCanGoOutside (true, 0, 0);
				rotated = false;
				Girl.copy_girl.setHiddenInCave (false);
		    	Boy.copy_boy.setCanMoveInCave (true);
			}
		}
	  
	}



}
