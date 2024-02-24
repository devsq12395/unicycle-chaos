using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public void OnTriggerEnter2D (Collider2D _collision){ 
        if (MG.I.isPaused) return;

        if (_collision.gameObject.layer == LayerMask.NameToLayer("char") || _collision.gameObject.layer == LayerMask.NameToLayer("wheel")) {
            Debug.Log (_collision.gameObject.name);
            MG.I.add_rating ("Boo", "Obstacle Hit!", 1);
        }
    }
}
