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

        PlayerPrefs.SetInt ("Tutorial", 0);

        M_LvlSel.I.setup ();
    }

    private void setup_player_prefs (){
        for (int i = 1; i < LVL_COUNT; i++){
            PlayerPrefs.SetInt($"Level{i}Stars", 0);
        }
    }

    public void go_to_game_lvl (int _lvl){
        PlayerPrefs.SetInt ("Lvl", _lvl);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
