using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlFollow : MonoBehaviour {
	public Girl girl;
	public float num;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform girl_transform = girl.transform;
		Transform camera_transform = this.transform;

		Vector3 girl_position = girl_transform.position;
		Vector3 camera_position = camera_transform.position;

		camera_position.x = girl_position.x;
		camera_position.y = girl_position.y/num;

		camera_transform.position = camera_position;
	}
}
