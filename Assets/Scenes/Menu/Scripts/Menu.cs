using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public static Menu I;
	public void Awake(){ I = this; }

    void Start (){
        PlayerPrefs.SetInt ("Tutorial", 0);

        M_LvlSel.I.setup ();
    }

    public void go_to_game_lvl (int _lvl){
        PlayerPrefs.SetInt ("Lvl", _lvl);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
