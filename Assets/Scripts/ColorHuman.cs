using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHuman : MonoBehaviour {

	public float SPEED;
	float speed;
	public float waitTime;
	bool canWalk = false;
	protected Rigidbody2D body = null;
	protected Animator animator = null;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		StartCoroutine (wait ());
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!canWalk) {
			stop ();
			stopWalkAnimation ();

		} else {
			walkSpeed ();
			walk ();
			walkAnimation ();
		}
	}

	protected void walk() {
		Vector3 vel = body.velocity;
		vel.x = speed;
		body.velocity = vel;
	}

	protected void stop() {
		speed = 0;
	}
	protected void walkSpeed() {
		speed = SPEED;
	}
	protected void walkAnimation() {
		animator.SetBool ("walk", true);
	}
	protected void stopWalkAnimation() {
		animator.SetBool ("walk", false);
	}

	IEnumerator wait() {
		yield return  new WaitForSeconds (waitTime);
		canWalk = true;
	}


	IEnumerator wait2() {
		yield return  new WaitForSeconds (waitTime);
		canWalk = false;
	}

	public void setCanWalk(bool val) {
		canWalk = val;
	}

	public void destroyHuman() {
		Destroy (gameObject);
	}
}
