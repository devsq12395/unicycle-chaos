using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Announce : MonoBehaviour {
    public static UI_Announce I;
    public void Awake() { I = this; }

    public GameObject go, gameCanvas;
    public Sprite i_boo, i_yeah;

    public void create_announce (string _type){
        GameObject _new = GameObject.Instantiate(go, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;;
        UIObj_Announce _comp = _new.GetComponent<UIObj_Announce> ();
        
        switch (_type) {
            case "Boo": 
                _comp.img.sprite = i_boo; 
                _comp.tweenTarg = 0;
                ContSounds.I.play ("boo" + Mathf.FloorToInt (UnityEngine.Random.Range (1, 3)));
                break;
            case "Yeah": 
                _comp.img.sprite = i_yeah; 
                _comp.tweenTarg = 1;
                ContSounds.I.play ("yea" + Mathf.FloorToInt (UnityEngine.Random.Range (1, 3)));
                break;
        }

        _new.transform.SetParent (gameCanvas.transform, false);
    }
}
