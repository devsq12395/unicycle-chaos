using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public static Menu I;
	public void Awake(){ I = this; }

    public GameObject goLvlSel;

    void Start (){
        M_LvlSel.I.setup ();
        ContAPI.I.show_ad_midroll ();
    }

    public void btn_play (){
        goLvlSel.SetActive (true);
        ContAPI.I.show_ad_midroll ();
    }

    public void btn_settings (){
        P_Settings.I.show (true);
    }

    public void go_to_game_lvl (int _lvl){
        PlayerPrefs.SetInt ("Lvl", _lvl);
        MasterScene.I.change_main_scene ("Game");
    }
}
