using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip noteClip;
    public AudioSource noteSoundPlayer;
    public static AudioManager instance;
	// Use this for initialization
	void Awake () {
        instance = this;
		
	}

    public void PlayNoteSound(AudioClip noteSound = null)
    {
        if(noteSound == null)
        {
            noteSound = noteClip;
        }
        noteSoundPlayer.PlayOneShot(noteSound);
    }
}
