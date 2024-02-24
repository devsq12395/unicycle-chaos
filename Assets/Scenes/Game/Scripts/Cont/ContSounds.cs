using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContSounds : MonoBehaviour {
    public static ContSounds I;
	public void Awake(){ I = this; }

    public AudioSource audioSource;

    public AudioClip boo1, boo2, yea1, yea2, bad, good, jump;

    public void play(string _sound) { 
        switch (_sound){
            case "boo1": audioSource.PlayOneShot(boo1); break;
            case "boo2": audioSource.PlayOneShot(boo2); break;
            case "yea1": audioSource.PlayOneShot(yea1); break;
            case "yea2": audioSource.PlayOneShot(yea2); break;

            case "bad": audioSource.PlayOneShot(bad); break;
            case "good": audioSource.PlayOneShot(good); break;

            case "jump": audioSource.PlayOneShot(jump); break;
        }
    }
}
