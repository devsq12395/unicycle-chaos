using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    public float JUMP_CD, curCd;

    void Start (){
        JUMP_CD = 10;
        curCd = 0;
    }

    void Update (){
        if (curCd > 0) {
            curCd -= Time.deltaTime;
            if (curCd <= 0) curCd = 0;
        }
    }

    public void OnTriggerEnter2D (Collider2D _collision){ 
        if (curCd > 0) return;

        if (_collision.gameObject.layer == LayerMask.NameToLayer("char")) {
            MG.I.add_rating ("Yeah", "Successful Jump!", 1);
            curCd = JUMP_CD;
        }
    }
}
