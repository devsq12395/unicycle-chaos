using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public static Menu I;
	public void Awake(){ I = this; }

    public int LVL_COUNT;

    void Start (){
        LVL_COUNT = 10;
        Application.targetFrameRate = 60;

        PlayerPrefs.SetInt ("Tutorial", 0);
        PlayerPrefs.SetInt ("LvlCount", LVL_COUNT);

        M_LvlSel.I.setup ();
    }

    private void setup_player_prefs (){
        if (PlayerPrefs.GetInt ("v.1.1") == 0) return;

        for (int i = 1; i < LVL_COUNT; i++){
            PlayerPrefs.SetInt($"Level{i}Stars", 0);
            PlayerPrefs.SetInt("BGM", 1);
            PlayerPrefs.SetInt("SFX", 1);
        }

        PlayerPrefs.SetInt ("v.1.0", 1);
    }

    public void go_to_game_lvl (int _lvl){
        PlayerPrefs.SetInt ("Lvl", _lvl);
        MasterScene.I.change_main_scene ("Game");
    }
}
