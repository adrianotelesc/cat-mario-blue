using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour {

	public GameObject dialogueManager;
	private int indexPassword;
	private bool locked;

	void Start(){
		IndexPassword = -1;
		Locked = true;
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			ComputerManager.instance.onComputer = true;
			ComputerManager.instance.computer = gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			dialogueManager.GetComponent<ComputerManager> ().onComputer = false;
		}
	}
	public bool Locked{
		get{ return locked; }
		set{ locked = value; }
	}


	public int IndexPassword{
		get{ return indexPassword; }
		set{ indexPassword = value; }
	}
}
