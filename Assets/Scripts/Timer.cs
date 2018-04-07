using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Timer : MonoBehaviour {

	public Text textTime;
	public float time;
	private int minutes;
	private int seconds;
	public GameObject player;

	void FixedUpdate () {
		if(player.GetComponent<PlayerController>().Alive && !GameManager.instance.IsComplete) {
			if (time > 0) {
				time -= Time.deltaTime;
				minutes = (int) time/60;
				seconds = (int) time%60;
				textTime.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
			} else {
				player.GetComponent<PlayerController>().Alive = false;
			}
		}
	}

}
