using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public float JUMP_CD, curCd;

    public void OnTriggerEnter2D (Collider2D _collision){ 
        UI_GameOver.I.show (true);
    }
}
