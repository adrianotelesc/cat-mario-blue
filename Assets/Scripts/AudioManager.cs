using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	// Soundtracks
	public AudioClip[] clipsSoundTrack;
	public AudioSource soundTrack;

	// SoundFXs
	public AudioClip[] clipsFx;
	public AudioSource soundFx;

	public static AudioManager instance;

	void Awake() {
		if(instance == null) {
			instance = this;
			//DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (gameObject);
		}
	}


	void Update () {
		if(!soundTrack.isPlaying) {
			soundTrack.clip = clipsSoundTrack [0];
			soundTrack.Play ();
		}
	}

	public void PlaySoundFX(int index) {
		soundFx.clip = clipsFx[index];
		soundFx.Play ();
	}

	public void PlaySoundTrack(int index) {
		soundTrack.clip = clipsSoundTrack[index];
		soundTrack.Play ();
	}

}
