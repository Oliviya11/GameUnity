using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	protected virtual void OnGirlHit(Girl girl) {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();

		if (girl != null) {
			OnGirlHit (girl);
		    CollectedHide ();
		}
	}

	public void CollectedHide() {
		Destroy (gameObject);
	}
}
