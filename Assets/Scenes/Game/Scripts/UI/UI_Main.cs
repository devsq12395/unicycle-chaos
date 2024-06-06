using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Main : MonoBehaviour {
    public static UI_Main I;
    public void Awake() { I = this; }

    public GameObject goTut;
    public TextMeshProUGUI t_boo, t_yeah, t_timer;

    void Update (){
        update_score ();
        update_timer (MG.I.timer);
    }

    public void update_score() {
        t_boo.text = $"Boo: {MG.I.get_val ("Boo")}";
        t_yeah.text = $"Yeah: {MG.I.get_val ("Yeah")}";
    }

    public void update_timer (float _secLeft){
        if (_secLeft < 0) _secLeft = 0;
        
        int _m = Mathf.FloorToInt(_secLeft / 60);
        int _s = Mathf.FloorToInt(_secLeft % 60);
        string _res = string.Format("{0}:{1:00}", _m, _s);

        t_timer.text = _res;
    }

    public void close_tut (){
        goTut.SetActive (false);
        MG.I.resume_game ();
    }
}
