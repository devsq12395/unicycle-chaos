using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContAPI : MonoBehaviour {
    public static ContAPI I;
    private float adCooldownTimer = 0f;
    public float adCooldownDuration = 10f;

    public void Awake() { 
        I = this; 
        GameDistribution.OnPauseGame += on_api_pause;
    }

    void Update() {
        if (adCooldownTimer > 0) {
            adCooldownTimer -= Time.deltaTime;
        }
    }

    public void show_ad_midroll() {
        if (adCooldownTimer <= 0) {
            GameDistribution.Instance.ShowAd();
            adCooldownTimer = adCooldownDuration;
        } else {
            Debug.Log("Ad cooldown active. Please wait.");
        }
    }

    public void on_api_pause() {
        ContSounds.I.force_mute();
    }

    public void on_api_unpause() {
        ContSounds.I.force_unmute();
    }
}
