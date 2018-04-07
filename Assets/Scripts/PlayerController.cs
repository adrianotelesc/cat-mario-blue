using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : CharacterController {

	public override void Move () {
		if(OnLadder && Input.GetKeyDown ("up")){
			Climbing = true;
		}
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		if (!Climbing) {
			Rigbody.gravityScale = 1;
			Rigbody.velocity = new Vector2 (x*velocity, GetComponent<Rigidbody2D> ().velocity.y);	
		}else {
			Rigbody.velocity = new Vector2 (x*(velocity*0.5f), y*(velocity*0.5f));
			Rigbody.gravityScale = 0f;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			if((Grounded || Climbing)) {
				AudioManager.instance.PlaySoundFX (0);
				Rigbody.AddForce (new Vector2 (Rigbody.velocity.x, jumpForce));
				if (Climbing)
					Climbing = false;
			}	
		}
		if (x > 0 && !FacingRight) {
			Flip ();
		} else if (x < 0 && FacingRight) {
			Flip ();
		} 
	}

	public override void Animation () {
		if (!Grounded && !Climbing) {
			CharAnimator.jump (true);
		} else {
			CharAnimator.jump (false);
		}
		if ((Rigbody.velocity.x != 0) && Grounded) {
			CharAnimator.walk (Mathf.Abs (Rigbody.velocity.x));
		} else {
			CharAnimator.walk (Mathf.Abs (0));
		}

		if (Climbing) {
			CharAnimator.climb (Mathf.Abs (Rigbody.velocity.x + Rigbody.velocity.y));
		} else {
			CharAnimator.climb (Mathf.Abs (Rigbody.velocity.x + Rigbody.velocity.y));
		}
	}

	private void Flip () {
		FacingRight = !FacingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	protected override void Die () {
		base.Die ();
		CharAnimator.die (true);
		AudioManager.instance.PlaySoundFX (1);
		AudioManager.instance.PlaySoundTrack (1);
		GameManager.instance.IsOver = true;
	}
		
}
