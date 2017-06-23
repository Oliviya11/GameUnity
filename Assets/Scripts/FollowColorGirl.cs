using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowColorGirl : MonoBehaviour {
	public ColorGirl girl;
	public float num;
	public float pos_x, pos_y;
	bool fall = false;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
		if (!fall) {
			followByGirl ();
		} else {
			notFollow ();

		}
	}

	void followByGirl() {
		if (girl != null) {
			Transform girl_transform = girl.transform;
			Transform camera_transform = this.transform;

			Vector3 girl_position = girl_transform.position;
			Vector3 camera_position = camera_transform.position;

			camera_position.x = girl_position.x;
			camera_position.y = girl_position.y / num;

			camera_transform.position = camera_position;
		}
	}

	void notFollow() {
		Transform camera_transform = this.transform;
		Vector3 camera_position = camera_transform.position;
		camera_position.x = pos_x;
		camera_position.y = pos_y;
	}
	public void setFall(bool val) {
		Debug.Log ("fall");
		fall = val;
	}
}
