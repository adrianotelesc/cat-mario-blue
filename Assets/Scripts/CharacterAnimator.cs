using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour {

	private Animator anim;

	public void Awake () {
		Anim = GetComponent <Animator> ();
	}

	public void jump (bool state) {
		Anim.SetBool ("Jumping", state);
	}

	public void walk (float value) {
		Anim.SetFloat ("Running", value);
	}

	public void climb(float value) {
		Anim.SetFloat ("Climbing", value);
	}

	public void die (bool state) {
		Anim.SetBool ("Dying", state);
	}
		

	public Animator Anim {
		get { return anim; }
		set { anim = value; }
	}
}
