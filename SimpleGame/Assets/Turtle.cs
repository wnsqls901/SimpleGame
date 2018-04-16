using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {

	public Vector2 speed = new Vector2(1, 1);
	Rigidbody2D rigid;

	private Vector2 movement;
	void Start() {
		rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		movement = new Vector2 (
			speed.x * inputX * 0.15f,
			speed.y * inputY * 0.15f);
	}
	void FixedUpdate() {
		rigid.velocity = movement;
		movement = new Vector2 (0, 0);
	}

}
