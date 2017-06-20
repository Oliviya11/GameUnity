using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMonster : MonoBehaviour {

	public Collider2D head, body;
	public bool hidden;
	Renderer rend = null;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void die() {
		Destroy (gameObject);
	}
}
