using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rigid;
	SpriteRenderer render;
	Animator animator;
	float inputX;
	float inputY;

	public Vector2 moveSpeed = new Vector2(150, 150);

	private Vector2 movement;


	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		render = gameObject.GetComponentInChildren<SpriteRenderer> ();
		animator = gameObject.GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxisRaw ("Horizontal");
		inputY = Input.GetAxisRaw ("Vertical");
		if (inputX == 0 && inputY == 0) {
			animator.SetBool ("isMoving", false);
		}
		if (inputX < 0) {
			render.flipX = true;
			animator.SetInteger ("Direction", -1);
			animator.SetBool ("isMoving", true);
		} else if (inputX > 0) {
			render.flipX = false;
			animator.SetInteger ("Direction", 1);
			animator.SetBool ("isMoving", true);
		}
		if (inputY != 0) {
			animator.SetInteger ("Direction", 1);
			animator.SetBool ("isMoving", true);
		}
	}

	void FixedUpdate() {
		Move ();
	}
	void Move() {
		movement = new Vector2 (
			moveSpeed.x * inputX * Time.deltaTime,
			moveSpeed.y * inputY * Time.deltaTime
		);
		rigid.velocity = movement;
	}
}
