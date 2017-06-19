using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {
	public float speed;
	Rigidbody2D body = null;
	SpriteRenderer sr = null;
	Animator animator = null;
	bool isGrounded = false;
	bool jumpActive = false;
	float jumpTime = 0f;
	Transform heroParent = null;
	float walkTime = 0;

	public float maxJumpTime = 2f;
	public float jumpSpeed = 2f;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		animator = GetComponent<Animator> ();
	}


	void FixedUpdate () {
		float value = Input.GetAxis ("Horizontal");
		walk (value);
		flipPicture (value);
		walkAnimation(value);
		jump ();
		checkIfIsGrounded ();
		jumpAnimation ();
		heroParent = transform.parent;
	}

	void walk(float value)
	{
		if (Mathf.Abs (value) > 0) {
			Vector2 vel = body.velocity;
			if (Time.time - walkTime > 4f) {
				vel.x = value * speed*1.5f;

			//	Debug.Log ("run);
			} else {
				
				vel.x = value * speed;
			}
			body.velocity = vel;

		} else {
			walkTime = Time.time;
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
	void walkAnimation(float value) {
		if (Mathf.Abs (value) > 0) {
			if (Time.time - walkTime > 4f) {
				animator.SetBool ("run", true);
			//	Debug.Log ("run);
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
					vel.y = jumpSpeed * (1.0f - jumpTime / maxJumpTime);
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

}
