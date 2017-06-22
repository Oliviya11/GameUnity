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
	// Use this for initialization
	void Start () {

	}

	void FixedUpdate () {
		if (rotator.isRotated ())
			Girl.copy_girl.setCanSeeHidden (true);
		else 
			Girl.copy_girl.setCanSeeHidden (false);

		if (rotator.getCanMoveInCave ())
			Girl.copy_girl.setCanMove (true);

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
		if (isGirlInCave && !Girl.copy_girl.isDead()) {
			Girl.copy_girl.setCanMove (false);
			rotator.setCanMoveInCave (false);
			rotator.rotateSide ();
			float cur_pos = Girl.copy_girl.transform.position.x;
			if (!rotated) {
				Girl.copy_girl.setCanGoOutside (false, cur_pos - border_a, cur_pos + border_b);
			        rotated = true;
				Girl.copy_girl.setHiddenInCave (true);
			}
			else {
				Girl.copy_girl.setCanGoOutside (true, 0, 0);
				rotated = false;
				Girl.copy_girl.setHiddenInCave (false);
			}
		}
			

	}
}
