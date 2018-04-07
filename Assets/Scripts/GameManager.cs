using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameObject player;
	private bool isOver, isComplete;

	void Awake() {
		if(instance == null) {
			instance = this;
			//DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	void FixedUpdate () {
		
		if(IsComplete) {
			GameComplete ();
			if(Input.GetKeyDown ("return")) {
				SceneManager.LoadScene ("Menu");
			}
		}

		if(IsOver) {
			GameOver ();
			if(Input.GetKeyDown ("return")){
				SceneManager.LoadScene ("Main");
			}
		}

	}


	void GameOver () {
		UIManager.instance.GameOverUI ();
	}

	void GameComplete () {
		UIManager.instance.GameCompleteUI ();
	}

	public bool IsOver {
		get { return isOver; }
		set { isOver = value; }
	}

	public bool IsComplete {
		get { return isComplete; }
		set { isComplete = value; }
	}
}
