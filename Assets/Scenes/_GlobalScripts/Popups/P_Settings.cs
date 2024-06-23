using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class P_Settings : MonoBehaviour {
    public static P_Settings I;
    public void Awake(){ 
        I = this; 
        set_text ();
    }

    public GameObject go, goBtnsMenu, goBtnsGame;
    public AudioSource sourceSound, sourceMusic;
    public TextMeshProUGUI tSound, tMusic;

    void Start (){
        on_load ();
    }

    public void on_load (){
        sourceSound = ContSounds.I.sourceSound;
        sourceMusic = ContSounds.I.sourceMusic;

        sourceSound.mute = (PlayerPrefs.GetInt("SFX") != 1);
        sourceMusic.mute = (PlayerPrefs.GetInt("BGM") != 1);
    }

    public void btn_toggle (string _type){
        ContSounds.I.play ("click");
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
        Time.timeScale = (_isShow) ? 0f : 1f;

        if (_isShow) {
            ContAPI.I.show_ad_midroll ();

            string[] _scenes = MasterScene.I.get_loaded_scenes ();

            bool _isMainMenu = _scenes.Contains ("Menu");

            goBtnsMenu.SetActive (_isMainMenu);
            goBtnsGame.SetActive (!_isMainMenu);
        }
    }

    public void btn_home (){
        ContAPI.I.show_ad_midroll ();
        MasterScene.I.change_main_scene ("Menu");
        show (false);
    }
}
