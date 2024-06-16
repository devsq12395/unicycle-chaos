using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class P_Settings : MonoBehaviour {
    public static P_Settings I;
    public void Awake(){ 
        I = this; 
        set_text ();
    }

    public GameObject go;
    public AudioSource sourceSound, sourceMusic;
    public TextMeshProUGUI tSound, tMusic;

    public void btn_toggle (string _type){
        switch (_type){
            case "sound":
                sourceSound.mute = !(PlayerPrefs.GetInt("SFX") == 1);
                break;
            case "music":
                sourceMusic.mute = !(PlayerPrefs.GetInt("BGM") == 1);
                break;
        }

        set_text ();
    }

    private void set_text (){
        bool    soundEnabled = PlayerPrefs.GetInt("SFX") == 1,
                musicEnabled = PlayerPrefs.GetInt("BGM") == 1;
        tSound.text = (soundEnabled) ? "ON" : "OFF";
        tMusic.text = (musicEnabled) ? "ON" : "OFF";
    }

    public void show (bool _isShow){
        go.SetActive (_isShow);

        if (!_isShow && Time.timeScale == 0) {
            Time.timeScale = 1f;
        }
    }
}
