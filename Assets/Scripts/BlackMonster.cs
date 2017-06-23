using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMonster : MonoBehaviour {

	AudioSource attackSource = null;
	AudioSource dieSource = null;
	public AudioClip attackSound = null;
	public AudioClip dieSound = null;
	Vector3 pointA, pointB;
	Rigidbody2D myBody = null;
	public float moveBy;
	float speed;
	public float SPEED;
	SpriteRenderer sr = null;
	Animator animator = null;
	Mode mode, oldMode;
	Renderer rend = null;
	Vector3 mypos;
	public float jumpHeighht;
	bool canMove = true;
	bool isDead = false;
	bool follow = false;

	protected enum Mode {
		GoToA,
		GoToB,
		Stand,
		GoAway
		//...
	}
	// Use this for initialization
	void Start () {
		
		attackSource = gameObject.AddComponent<AudioSource> ();
		attackSource.clip = attackSound;

		dieSource = gameObject.AddComponent<AudioSource> ();
		dieSource.clip = dieSound;

		myBody = this.GetComponent<Rigidbody2D> ();
		pointA = this.transform.position;
		pointB = pointA;
		pointB.x += moveBy;
		sr = GetComponent<SpriteRenderer> ();
		mode = Mode.GoToB;
		animator = GetComponent<Animator> ();
		rend = GetComponent<Renderer> ();
		mypos = this.transform.position;
		speed = SPEED;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (canMove) {
			float value = getDirection ();
			walk (value);
			walkAnimation (value);
			flipPicture (value);
			OnGirlNoticed ();
		} else if (isDead) {
			StartCoroutine (dieAnimation ());

		} else {
			animator.SetBool ("walk", false);
		}

	}

	protected void walk(float value)
	{
		if (Mathf.Abs (value) > 0) {
			Vector2 vel = myBody.velocity;
			vel.x = value * speed;
			myBody.velocity = vel;

		}
	}
	protected void flipPicture(float value) 
	{

		if (value < 0) {
			sr.flipX = false;
		} else if (value > 0) {
			sr.flipX = true;
		}

	}

	protected float getDirection() {
		
			Mode oldModeIn;
			if (mode == Mode.GoToB) {
				if (transform.position.x < pointB.x && moveBy < 0 || transform.position.x > pointB.x && moveBy > 0) {
					oldModeIn = mode;
					mode = Mode.Stand;
				if(!follow) StartCoroutine (standLooking (2.0f, oldModeIn));

				}
				if (moveBy > 0)
					return 1;
				return -1; //Move left
			} else if (mode == Mode.GoToA) {
				if (transform.position.x >= pointA.x && moveBy < 0 || transform.position.x <= pointA.x && moveBy > 0) {
					oldModeIn = mode;
					mode = Mode.Stand;
				if (!follow) StartCoroutine (standLooking (2.0f, oldModeIn));
				}
				if (moveBy > 0)
					return -1;
				return 1; //Move right
			}

		if (mode == Mode.GoAway)
			return -1;

		return 0; //No movement
	}

	protected void walkAnimation(float value) {
		if (Mathf.Abs (value) > 0) {
			animator.SetBool ("walk", true);
		} else {
			animator.SetBool ("walk", false);
		}
	}


	protected IEnumerator standLooking(float duration, Mode oldMode) {
		animator.SetBool ("walk", false);
		Vector2 vel = myBody.velocity;
		vel.x =0;
		myBody.velocity = vel;
		yield return new WaitForSeconds (duration);
		//Continue excution in few seconds
		//Other actions...
		toggle(oldMode);
		animator.SetBool ("walk", true);
	}




	void toggle(Mode oldMode) {
		if (oldMode == Mode.GoToA) {
			mode = Mode.GoToB;
		}
		else {
			mode = Mode.GoToA;
		}
	}

	 void OnGirlNoticed() {
		Mode myoldMode=Mode.Stand;

		Girl girl = Girl.copy_girl;
		float girlPos = girl.transform.position.x;
		if (girl.isDead ()) muteAttackSound ();
		if (follow) playAttackSound ();
		else        muteAttackSound ();
		if ((((girlPos < pointA.x && girlPos > pointB.x && moveBy < 0) || (girlPos > pointA.x && girlPos < pointB.x && moveBy > 0)
		    && Mathf.Abs (Girl.copy_girl.transform.position.y - transform.position.y) < 0.5f && !girl.isDead ()) || follow) && canMove && !isDead
		    && !girl.isHidden ()) {
			speed = SPEED * 1.5f;
			findGirlLocation ();
			myoldMode = mode;
			follow = true;
		} else if (girl.isHidden () && follow) {
			speed = SPEED;
			mode = oldMode;
			if (mode == Mode.GoToA) {
				mode = Mode.GoToB;
			} else {
				mode = Mode.GoToA;
			}

			follow = false;
			muteAttackSound ();
		} 
		
	}



	void findGirlLocation() {
		float girlPos = Girl.copy_girl.transform.position.x;
		if (girlPos  < transform.position.x && moveBy<0 ||
			girlPos  > transform.position.x && moveBy>0)
			mode = Mode.GoToB;
		else
			mode = Mode.GoToA;
		oldMode = mode;
	}

	void OnTriggerEnter2D(Collider2D collider) {

		Girl girl = collider.GetComponent<Girl> ();
		if (girl != null && !girl.isDead() && !girl.isHidden()) {
			girl.hitWithBlackMonster();
			girl.setDead (true);
			canMove = false;
		}
	}
	IEnumerator dieAnimation() {
		canMove = false;
		animator.SetBool ("die", true);
		yield return new WaitForSeconds (1.5f);
		Destroy (this.gameObject);
	}

	public void setDead(bool val) {
		isDead = val;
		canMove = false;
	}

	void playAttackSound() {
		if (!attackSource.isPlaying) attackSource.Play ();
	}

	void muteAttackSound() {
		attackSource.Stop ();
	}
}
