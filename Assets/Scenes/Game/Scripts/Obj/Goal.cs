using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public float JUMP_CD, curCd;

    public void OnTriggerEnter2D (Collider2D _collision){ 
        if (MG.I.isPaused) return;

        if (_collision.gameObject.layer == LayerMask.NameToLayer("char") || _collision.gameObject.layer == LayerMask.NameToLayer("wheel")) {
            UI_GameOver.I.show (true);
        }
    }
}
