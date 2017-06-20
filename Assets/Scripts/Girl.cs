using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {

	public AudioClip screamSound = null;
	public AudioClip painSound = null;
	public AudioClip hitSound = null;
	public float speed;
	public float maxJumpTime = 2f;
	public float jumpSpeed = 2f;
	public static Girl copy_girl;

	Rigidbody2D body = null;
	SpriteRenderer sr = null;
	Animator animator = null;
	bool isGrounded = false;
	bool jumpActive = false;
	bool dead = false;
	bool canGoOutside = true;
	bool canSeeHidden = false;
	bool canMove = true;
	float jumpTime = 0f;
	float goFrom, goTo;
	Transform heroParent = null;
	float walkTime = 0, waitNearCaveTime = 0;
	AudioSource screamSource, painSource, hitSource;
	Vector3 pos;

	// Use this for initialization
	void Start () {
		copy_girl = this;
		body = this.GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
		initSoundSources ();
		pos = this.transform.position;
	}


	void FixedUpdate () {
		if (!dead) {
			float value = 0;
			if (canMove) 
				value = Input.GetAxis ("Horizontal");
				walk (value);
				flipPicture (value);
				walkAnimation (value);
				jump ();
				checkIfIsGrounded ();
				jumpAnimation ();
				heroParent = transform.parent;
			
		} else {
			dieAnimation ();
		}
	}

	void initSoundSources() {
		screamSource = gameObject.AddComponent<AudioSource> ();
		screamSource.clip = screamSound;

		painSource = gameObject.AddComponent<AudioSource> ();
		painSource.clip = painSound;

		hitSource = gameObject.AddComponent<AudioSource> ();
		hitSource.clip = hitSound;
	}

	void walk(float value)
	{
		

		if (Mathf.Abs (value) > 0) {
			Vector2 vel = body.velocity;
			if (canGoOutside || (this.transform.position.x > goFrom && value < 0) || (this.transform.position.x < goTo && value > 0)) {
				if (Time.time - walkTime > 4f) {
					vel.x = value * speed * 1.5f;
				} else {
					vel.x = value * speed;
				}
				body.velocity = vel;
			} else {
				walkTime = Time.time;

			}
					
		} else {
			walkTime = Time.time;
		}
		waitNearCaveTime = Time.time;
	}

	public void setCanGoOutside(bool val, float a, float b) {
		canGoOutside = val;
		goFrom = a;
		goTo = b;
	}

	public bool getCanGoOutside() {
		return canGoOutside;
	}


	void flipPicture(float value) 
	{

		if (value < 0) {
			sr.flipX = true;
		} else if (value > 0) {
			sr.flipX = false;
		}

	}
	void walkAnimation(float value) {
		if (Mathf.Abs (value) > 0) {
			if (Time.time - walkTime > 4f) {
				animator.SetBool ("run", true);
				//animator.SetBool ("die", true);
			} else {
				animator.SetBool ("walk", true);

			}
		} else {
			animator.SetBool ("walk", false);
			animator.SetBool ("run", false);
		}
	}

	void jump() {
		 

			if (Input.GetButtonDown ("Jump") && isGrounded) {
				this.jumpActive = true;
			}

			if (this.jumpActive) {
				//	muteMusicOnRun ();
				if (Input.GetButton ("Jump")) {
					this.jumpTime += Time.deltaTime;
					if (this.jumpTime < this.maxJumpTime) {
					
						  Vector2 vel = body.velocity;
						  

						
					if (!canGoOutside && (transform.position.x < goFrom || transform.position.x > goTo)) {
						vel.y = 0;
						vel.x = 0;
						//transform.position = new Vector3(this.transform.position.x, pos.y, this.transform.position.z);
					} else {
						vel.y = jumpSpeed * (1.0f - jumpTime / maxJumpTime);
					}
						  body.velocity = vel;
					  
					}
				} else {
					this.jumpActive = false;
					this.jumpTime = 0;
					//	soundJump = true;
				}
			}
		

	}

	void jumpAnimation() {
		if (this.isGrounded) {
			animator.SetBool ("jump", false);
		} else {
			animator.SetBool ("jump", true);
		}
	}

	void checkIfIsGrounded(){
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layer_id = 1 << LayerMask.NameToLayer ("Ground");

		RaycastHit2D hit = Physics2D.Linecast (from, to, layer_id);

		if (hit) {
			if (isGrounded) {
				
				isGrounded = false;

			}
			isGrounded = true;
			SetNewParent (this.transform, hit.transform);
		} else {
			isGrounded = false;
			SetNewParent (this.transform, heroParent);
		}

		Debug.DrawLine (from, to, Color.red);
	}
	void SetNewParent(Transform obj, Transform newObject){
		obj.transform.parent = newObject;
	}

	void dieAnimation() {
		animator.SetBool ("die", true);
		animator.SetBool ("run", false);
		animator.SetBool ("walk", false);
		animator.SetBool ("jump", false);
	}

	public void hurtAnimation() {
		animator.SetBool ("hurt", true);
	}

	public void stopHurtAnimation() {
		animator.SetBool ("hurt", false);
	}

	public void setDead(bool val) {
		dead = val;
	}
	public void scream() {
		if (!dead) screamSource.Play ();
	}

	public void setCanSeeHidden(bool val) {
		canSeeHidden = val;
	}

	public bool getCanSeeHidden() {
		return canSeeHidden;
	}

	public void setCanMove(bool val) {
		canMove = val;
	}

	public bool getCanMove() {
		return canMove;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		
		CollideWithMonster (collider);
	}

	void CollideWithMonster(Collider2D collider) {
		GroundMonster monster = collider.GetComponent<GroundMonster> ();
		if (monster != null && (!monster.hidden || getCanSeeHidden())) {
			if (monster.body == collider) {
				sayAboutPain ();
				setDead (true);
			} else if (monster.head == collider && !dead) {
				smashPlay ();
				monster.die ();
			}
		}
	}

	void sayAboutPain(){
		painSource.Play ();
	}

	void smashPlay() {
		hitSource.Play ();
	}
}
