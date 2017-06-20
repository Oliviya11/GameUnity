using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour {
	public static Boy copy_boy;
	public AudioClip hurtSound = null;
	public float speed;
	bool dead = false;
	bool canMove = false;
	Animator animator = null;
	SpriteRenderer sr = null;
	float walkTime = 0;
	Rigidbody2D body = null;
	bool canGoOutside = true;
	AudioSource hurtSource=null;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		sr = GetComponent<SpriteRenderer> ();
		initSoundSources ();
		copy_boy = this;
	}

	void initSoundSources() {
		hurtSource = gameObject.AddComponent<AudioSource> ();
		hurtSource.clip = hurtSound;

	}


	// Update is called once per frame
	void FixedUpdate () {
		if (!dead) {
			if (canMove) {
				float value = Input.GetAxis ("Horizontal");
				walk (value);
				walkAnimation (value);
				flipPicture (value);
			}
		} else {
			dieAnimation ();
		}
	}

	void walk(float value)
	{

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = body.velocity;
			if (canGoOutside) {

				if (Time.time - walkTime > 4f) {
					vel.x = value * speed * 1.5f;
				} else {
					vel.x = value * speed;
				}
				body.velocity = vel;
			} else  {
				walkTime = Time.time;
				vel.x = 0;
			}

		} else {
			walkTime = Time.time;
		}
	}

	void walkAnimation(float value) {
		if (Mathf.Abs (value) > 0) {
		    animator.SetBool ("run", true);
		} else {
			animator.SetBool ("run", false);
		}
	}

	void flipPicture(float value) 
	{

		if (value < 0) {
			sr.flipX = true;
		} else if (value > 0) {
			sr.flipX = false;
		}

	}

	void OnTriggerEnter2D(Collider2D collider) {

		CollideWithMonster (collider);
	}

	void CollideWithMonster(Collider2D collider) {
		GroundMonster monster = collider.GetComponent<GroundMonster> ();
		if (monster != null) {
			if (monster.body == collider) {
				setDead (true);
				hurt();
			} 
		}
	}
	public void setDead(bool val) {
		dead = val;
	}

	void dieAnimation() {
		animator.SetBool ("die", true);
		animator.SetBool ("run", false);
	}

	void hurt() {
		hurtSource.Play ();
	}
	public void giveFreedom() {
		canMove = true;
	}
	public bool isFree() {
		return canMove;
	}
}
