using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	public GameObject player;

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "Ground") {
			player.GetComponent<PlayerController> ().Grounded = true;
		}
	}


	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Ground") {
			player.GetComponent<PlayerController> ().Grounded = false;
		}

	}

}
