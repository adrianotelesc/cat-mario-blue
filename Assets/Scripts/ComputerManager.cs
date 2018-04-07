using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ComputerManager: MonoBehaviour {

	public static ComputerManager instance; 
    public List<int> indexList = new List<int>();
	public string[] passwordHints;
	public string[] passwords;
 	public GameObject dialogBox;
	public bool dialogActive;
	public Text passwordHint;
	public InputField passwordField;
	public GameObject computer;
	public int indexPassword;
	public bool onComputer;
	public GameObject player;
	public int computersRemaining;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
			//DontDestroyOnLoad (this.gameObject);
		}
	}

	void Start () {
		dialogBox.SetActive (false);
		computersRemaining = 10;
	}

		
	void Update () {
		
		// Para abrir a tela de senha
		if(Input.GetKeyDown("up") && onComputer && computer.GetComponent<Computer> ().Locked){
			player.GetComponent<PlayerController>().Moving = false;
			if (computer.GetComponent<Computer> ().IndexPassword == -1) {
				indexPassword = IndexRandom ();
				computer.GetComponent<Computer> ().IndexPassword = indexPassword;
			}
			showBox ();
		}

		// Para dar submit na senha inserida
		if (Input.GetKey ("return") && dialogActive) {
			if (verifyPassword ()) {
				computersRemaining--;
				player.GetComponent<PlayerController> ().Moving = true;
				computer.GetComponent<Animator> ().SetBool ("Check", true);
				computer.GetComponent<Computer> ().Locked = false;
				AudioManager.instance.PlaySoundFX (5);
			} else {
				AudioManager.instance.PlaySoundFX (4);
			}
		}

		// Para fechar o dialogo 
		if(Input.GetKey("escape")) {
			closeBox ();
			player.GetComponent<PlayerController>().Moving = true;
		}

		if(computersRemaining == 0){
			if(GameManager.instance.IsComplete == false){
				AudioManager.instance.PlaySoundTrack (2);
			}
			GameManager.instance.IsComplete = true;
			player.GetComponent<PlayerController>().Moving = false;
		}
    }

	// Retorna um índice aleatório para as senhas
	public int IndexRandom() {
		if (Mathf.Abs (0 - passwords.Length) > indexList.Count) {
			while (true) {
				int indexRandom = Random.Range (0, passwords.Length);
				if (!indexList.Contains (indexRandom)) {
					indexList.Add (indexRandom);
					return indexRandom;
				}
			}
		}
		return -1;
    }

	// Verifica se a senha informada pelo jogador está correta
	public bool verifyPassword() {
		if (passwordField.text.ToLower () == passwords[computer.GetComponent<Computer> ().IndexPassword]) {
			closeBox ();
			return true;
		} else {
			passwordField.ActivateInputField ();
			passwordField.Select ();
			return false;
		}
	}

	// Abre o dialogo com o computador
	public void showBox() {
		if (!dialogActive) {
			passwordHint.text = passwordHints [computer.GetComponent<Computer> ().IndexPassword];
			dialogActive = true;
			dialogBox.SetActive (dialogActive);
			passwordField.ActivateInputField ();
			passwordField.Select ();
		}
	}

	// Fecha o dialogo com o computador
	public void closeBox(){
		if (dialogActive) {
			dialogActive = false;
			passwordField.text = "";
			dialogBox.SetActive (dialogActive);
		}
	}
		
}
