using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
	public float speed;
	Rigidbody2D body;
	Vector2 moveBy,  moveUp, moveDown;
	Vector3 pos;
	float changing_time;
	public float posToMoveDown;
	public float wait_time;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		pos = this.transform.localPosition;
		moveUp = new Vector2 (0, speed);
		moveDown = new Vector2 (0, -speed);
		moveBy = moveDown;
	//	changing_time = wait_time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		move ();

	}
	 
	void move() {
		if (changing_time <= 0) {
			if (transform.localPosition.y > pos.y) {
				changing_time = wait_time;
				moveBy = moveDown;
			//	body.MovePosition (body.position + moveBy * Time.fixedDeltaTime);
			} else if (transform.localPosition.y < posToMoveDown) {
				changing_time = wait_time;
				moveBy = moveUp;
				//body.MovePosition (body.position + moveBy * Time.fixedDeltaTime);
			}
			body.MovePosition (body.position + moveBy * Time.fixedDeltaTime);

		} else {
			waitForAWhile ();
		}
	}
	/*
	IEnumerator wait(Vector3 dir) {
		moveBy = dir;
		yield return new WaitForSeconds (wait_time);

	}
	*/
	void waitForAWhile() {
		changing_time -= Time.deltaTime;
	}


}
