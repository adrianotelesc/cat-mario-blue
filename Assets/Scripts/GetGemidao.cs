using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGemidao : MonoBehaviour {

	private bool onComputer;
	private bool gemendo;

	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown ("up") && OnComputer && !Gemendo){
			AudioManager.instance.PlaySoundTrack (3);
			Gemendo = true;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if(col.CompareTag ("Player")) {
			OnComputer = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if(col.CompareTag ("Player")) {
			OnComputer = false;
		}
	}

	public bool Gemendo {
		get{ return gemendo; }
		set{ gemendo = value; }
	}

	public bool OnComputer {
		get{ return onComputer; }
		set{ onComputer = value; }
	}
}
