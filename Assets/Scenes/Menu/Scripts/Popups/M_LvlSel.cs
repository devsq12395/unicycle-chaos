using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class M_LvlSel : MonoBehaviour {
    public static M_LvlSel I;
	public void Awake(){ I = this; }

    public GameObject go;

    public void setup (){
        go.SetActive (true);

        go.SetActive (false);
    }

    public void toggle_show (bool _isShow, int _lvl = 0){
        if (_isShow) {
            go.transform.position = new Vector3(Screen.width / 2, Screen.height * 1.5f, 0);
            
            go.SetActive(true);
            go.transform.DOMoveY(Screen.height / 2, 0.5f).SetEase(Ease.OutBounce);
        } else {
            go.transform.DOMoveY(Screen.height * 1.5f, 0.5f).OnComplete(() => go_to_game(_lvl));
        }
    }

    private void go_to_game (int _lvlIndex){
        Menu.I.go_to_game_lvl (_lvlIndex);
    }

}