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

    void Start (){
        on_load ();
    }

    public void on_load (){
        sourceSound.mute = (PlayerPrefs.GetInt("SFX") != 1);
        sourceMusic.mute = (PlayerPrefs.GetInt("BGM") != 1);
    }

    public void btn_toggle (string _type){
        bool _value = false;
        switch (_type){
            case "sound":
                _value = (PlayerPrefs.GetInt("SFX") == 1);
                sourceSound.mute = _value;
                PlayerPrefs.SetInt("SFX", (!_value) ? 1 : 0);
                break;
            case "music":
                _value = (PlayerPrefs.GetInt("BGM") == 1);
                sourceMusic.mute = _value;
                PlayerPrefs.SetInt("BGM", (!_value) ? 1 : 0);
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
