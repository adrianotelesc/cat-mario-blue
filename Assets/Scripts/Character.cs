using System.Collections;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour {

	private Rigidbody2D rigbody;
	private CharacterAnimator charAnimator;
	private bool grounded;
	private bool climbing;
	private bool onLadder;
	private bool facingRight;
	private bool alive;
	private bool moving;
	public float velocity;
	public float jumpForce;

	protected virtual void Awake () {
		Alive = true;
		Moving = true;
		FacingRight = true;
		CharAnimator = GetComponent<CharacterAnimator> ();
		Rigbody = GetComponent<Rigidbody2D> ();
	}

	protected virtual void Update () {
		if (Moving) {
			Move ();
		} else {
			Rigbody.velocity = Vector2.zero;
		}
		Animation ();
	}

	public abstract void Move ();
	public abstract void Animation ();

	protected virtual void Die () {
		Moving = false;
		Alive = false;
	}

	protected virtual void OnTriggerStay2D (Collider2D collider) {
		if (collider.gameObject.tag == "Ladder") {
			OnLadder = true;
		}

		if (collider.gameObject.tag == "Ground") {
			Grounded = true;
		}
	}
		
	protected virtual void OnTriggerExit2D (Collider2D collider) {
		if (collider.tag == "Ladder") {
			Climbing = false;
			OnLadder = false;
		}

		if (collider.gameObject.tag == "Ground") {
			Grounded = false;
		}

	}

	protected virtual void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Deadzone") {
			Die ();
		}
	}

	public CharacterAnimator CharAnimator {
		get { return charAnimator; }
		set { charAnimator = value; }
	}

	public bool Grounded {
		get { return grounded; }
		set { grounded = value; }
	}

	public Rigidbody2D Rigbody {
		get { return rigbody; }
		set { rigbody = value; }
	}

	public bool Climbing {
		get { return climbing; }
		set { climbing = value; }
	}

	public bool OnLadder {
		get { return onLadder; }
		set { onLadder = value; }
	}

	public bool Moving {
		get{ return moving; }
		set{ moving = value; }
	}

	public bool Alive {
		get{ return alive; }
		set{ alive = value; }
	}

	public bool FacingRight {
		get{ return facingRight; }
		set{ facingRight = value; }
	}

}
