using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour {

	public Vector2 speed = new Vector2(200, 200);
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
			speed.x * inputX * Time.deltaTime,
			speed.y * inputY * Time.deltaTime);
		
	}
	void FixedUpdate() {
		rigid.velocity = movement;
	}

}
