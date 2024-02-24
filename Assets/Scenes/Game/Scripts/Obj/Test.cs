using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public void OnTriggerEnter2D (Collider2D _collision){ Debug.Log ("coll 1");
        if (_collision.gameObject.layer == LayerMask.NameToLayer("platform")) {
            Debug.Log ("coll 2");
        }
    }
}
