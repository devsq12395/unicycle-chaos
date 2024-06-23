using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContAPI : MonoBehaviour {
    public static ContAPI I;
    public void Awake() { 
        I = this; 
        GameDistribution.OnPauseGame += on_api_pause;
    }

    public void show_ad_midroll () {
        GameDistribution.Instance.ShowAd();
    }

    public void on_api_pause (){
        ContSounds.I.force_mute ();
    }

    public void on_api_unpause (){
        ContSounds.I.force_unmute ();
    }
}
