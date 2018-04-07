using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour {
		
	void Update(){
		if(Input.GetKeyDown("return")) {
			GameObject.Find ("Subtitle").GetComponent<Animator> ().Play ("PressingStart");
			AudioManager.instance.PlaySoundFX(0);
			StartCoroutine (TimeToStart());
		}
	}

	IEnumerator TimeToStart(){
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene (1);
	}
}
