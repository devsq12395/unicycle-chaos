using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_GameOver : MonoBehaviour {
    public static UI_GameOver I;
    public void Awake() { I = this; }

    public GameObject go;
    public List<Image> i_stars;
    public Sprite i_starEmpty, i_starFull;

    public TextMeshProUGUI t_title, t_desc;

    public void show (bool _isWin){
        go.SetActive (true);

        MG.I.isGameOver = true;
        MG.I.pause_game ();

        t_title.text = (_isWin) ? "Level Complete!" : "Level Failed!";
        if (_isWin) ContSounds.I.play ("win");

        int _m = Mathf.FloorToInt(MG.I.timer / 60);
        int _s = Mathf.FloorToInt(MG.I.timer % 60);
        string _res = string.Format("{0}:{1:00}", _m, _s);

        t_desc.text = $"Total Time: {_res}";

        int _stars = 0, _index = 0;
        float timer = MG.I.timer;
        if (_isWin) {
            LvlDetails.I.starReqTimes.ForEach ((reqTime) => {
                if (LvlDetails.I.starReqTimes [_index] <= timer) {
                    _stars++;
                }
            });
            i_stars.ForEach ((star) => {
                star.sprite = (_stars >= _index + 1) ? i_starFull : i_starEmpty;
                _index++;
            });

            PlayerPrefs.SetInt ($"Level{MG.I.lvlNum}Stars", _stars);
        }
    }

    public void btn_try_again (){
        MG.I.change_scene ("Game");
    }

    public void btn_home (){
        MG.I.change_scene ("Menu");
    }

    public void btn_next (){
        int lvlCount = PlayerPrefs.GetInt ("LvlCount");
        if (MG.I.lvlNum < lvlCount) {
            PlayerPrefs.SetInt ("Lvl", MG.I.lvlNum + 1);
            MG.I.change_scene ("Game");
        } else {
            MG.I.change_scene ("Menu");
        }
    }
}
