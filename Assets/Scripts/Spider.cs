using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
	public float speed;
	Rigidbody2D body;
	Vector2 moveBy,  moveUp, moveDown;
	Vector3 pos;
	float changing_time;
	float posToMoveUp;
	public float posToMoveDown;
	public float wait_time;
	public float radius;

	bool attack = true;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		pos = this.transform.localPosition;
		moveUp = new Vector2 (0, speed);
		moveDown = new Vector2 (0, -speed);
		moveBy = moveDown;
		changing_time = wait_time;
		posToMoveUp = pos.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move ();
		OnGirlNoticed ();
	}
	 
	void move() {
		if (changing_time <= 0) {
			if (transform.localPosition.y > posToMoveUp) {
				changing_time = wait_time;
				moveBy = moveDown;
				attack = true;
			} else if (transform.localPosition.y < posToMoveDown) {
				moveBy = moveUp;
			   changing_time = wait_time;

			}
			body.MovePosition (body.position + moveBy * Time.fixedDeltaTime);

		} else {
			 waitForAWhile ();
		}
	}
	void waitForAWhile() {
		if (attack)
			changing_time -= Time.deltaTime;
		else 
			changing_time = 0;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();

		if (girl != null) {
			//LevelController.levelController.decreaseAntidoteNumber ();
			girl.scream ();
			if (!LevelController.levelController.hasAntidote ()) {
				girl.setDead (true);
			
			} else {
				girl.hurtAnimation ();
			}

				
		}
	}
	void OnTriggerExit2D(Collider2D collider) {
		Girl girl = collider.GetComponent<Girl> ();
		if (girl != null) {
			LevelController.levelController.decreaseAntidoteNumber ();
			girl.stopHurtAnimation ();
		}
	}

	void OnGirlNoticed() {
		
		if (Mathf.Abs (Girl.copy_girl.transform.position.y - transform.position.y) <= radius
		    && Mathf.Abs (Girl.copy_girl.transform.position.x - transform.position.x) <= 1f && attack) {

			if (Girl.copy_girl.transform.position.y + 1.5 < transform.position.y && attack) {
				body.MovePosition (body.position + moveDown * Time.fixedDeltaTime);
			} else {
				attack = false;
			}

		} 
	}
}
