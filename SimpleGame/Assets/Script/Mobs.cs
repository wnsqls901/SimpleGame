using System.Collections;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]
public class Mobs : MonoBehaviour
{
	static int AnimatorWalk = Animator.StringToHash("Walk");
	static int AnimatorAttack = Animator.StringToHash("Attack");
	Rigidbody2D rigid;

	public GameObject Target;

	public float movePower = 0.3f;

	SpriteRenderer render;

	Animator _animator;
	int movementFlag; //left:0 Right:1 Up:2 Down:3 Idle:4

	void Start()
	{
		rigid = gameObject.GetComponent<Rigidbody2D> ();
		render = gameObject.GetComponentInChildren<SpriteRenderer> ();
		_animator = GetComponentInChildren<Animator>();
		//StartCoroutine(Animate());
	}
	void Update() {
		if (Target.transform.position.x > transform.position.x) {
			render.flipX = true;
		} else {
			render.flipX = false;
		}
		Vector3 dir = Target.transform.position - transform.position;
		dir.Normalize ();

		transform.position += dir * Time.deltaTime * movePower;
	}
	IEnumerator Animate()
	{
		Vector3 moveVelocity = Vector3.zero;

		while (true)
		{
			movementFlag = Random.Range (0, 4);
			float rand = Random.Range (0f, 3f);
			if (movementFlag == 0) {
				moveVelocity = Vector3.left;
				_animator.SetBool(AnimatorWalk, true);
				transform.position += moveVelocity * movePower * rand;
				yield return new WaitForSeconds(1.3f);
			} else if (movementFlag == 1) {
				moveVelocity = Vector3.right;
				_animator.SetBool(AnimatorWalk, true);
				transform.position += moveVelocity * movePower * rand;
				yield return new WaitForSeconds(1.3f);
			} else if (movementFlag == 2) {
				moveVelocity = Vector3.up;
				_animator.SetBool(AnimatorWalk, true);
				transform.position += moveVelocity * movePower * rand;
				yield return new WaitForSeconds(1.3f);
			}else if(movementFlag == 3) {
				moveVelocity = Vector3.down;
				_animator.SetBool(AnimatorWalk, true);
				transform.position += moveVelocity * movePower * rand;
				yield return new WaitForSeconds(1.3f);
			}
		}
	}
}
