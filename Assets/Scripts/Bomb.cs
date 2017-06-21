using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour{
	public bool hidden, explode = false;
	public float timeToWaitBeforeActing;
	bool isDangerous = false;
	bool isGirlInteractWithBomb = false;
	public AudioClip explodeSound = null;
	AudioSource explodeSource = null;

	Animator animator = null;


	void Start () {
		animator = GetComponent<Animator> ();
		initSoundSources ();
	}
	void FixedUpdate() {
		explodeNow ();
	}

	void explodeNow() {
		if (explode)
				animator.SetBool ("explode", true);
			
	}
	void initSoundSources() {
		explodeSource = gameObject.AddComponent<AudioSource> ();
		explodeSource.clip = explodeSound;
	}

	void OnGirlHit (Girl girl)
	{
		if (!isDangerous) {
			LevelController.levelController.increaseBombNumber ();
			CollectedHide ();
		} else {
			StartCoroutine (actBomb (girl));
		}
	}

	public void setDangerous() {
		isDangerous = true;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();

		if (girl != null && (!hidden || girl.getCanSeeHidden())) {
			OnGirlHit (girl);
			isGirlInteractWithBomb = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();

		if (girl != null) {
			isGirlInteractWithBomb = false;
		}
	}

	public void CollectedHide() {
		Destroy (gameObject);
	}

	void explodePlay() {
		explodeSource.Play ();
	}

	IEnumerator actBomb(Girl girl) {
		yield return new WaitForSeconds (timeToWaitBeforeActing);
		explode = true;
		explodePlay ();
		if (isGirlInteractWithBomb) {
			girl.setDead (true);
		}
		yield return new WaitForSeconds (timeToWaitBeforeActing-2);
		Destroy (gameObject);

	}
}
