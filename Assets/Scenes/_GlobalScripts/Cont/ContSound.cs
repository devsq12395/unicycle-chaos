using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContSounds : MonoBehaviour {
    public static ContSounds I;
	public void Awake(){ I = this; }

    public AudioSource sourceSound, sourceMusic;
    public bool isForcedMute;

    public AudioClip boo1, boo2, yea1, yea2, bad, good, jump, click, win;

    public void play(string _sound) { 
        switch (_sound){
            case "boo1": sourceSound.PlayOneShot(boo1); break;
            case "boo2": sourceSound.PlayOneShot(boo2); break;
            case "yea1": sourceSound.PlayOneShot(yea1); break;
            case "yea2": sourceSound.PlayOneShot(yea2); break;

            case "bad": sourceSound.PlayOneShot(bad); break;
            case "good": sourceSound.PlayOneShot(good); break;

            case "jump": sourceSound.PlayOneShot(jump); break;

            case "click": sourceSound.PlayOneShot(click); break;
            case "win": sourceSound.PlayOneShot(win); break;
        }
    }

    public void force_mute (){
        isForcedMute = true;
        sourceSound.mute = true;
        sourceMusic.mute = true;
    }
    
    public void force_unmute (){
        isForcedMute = false;
        sourceSound.mute = false;
        sourceMusic.mute = false;
    }
}
