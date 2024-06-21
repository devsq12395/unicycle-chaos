using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody2D m_rb;
    public float JUMP_HEIGHT, jumpHeightCustom;
 
    private void Start() {
        m_rb = GetComponent<Rigidbody2D>();
        JUMP_HEIGHT = (jumpHeightCustom != 0) ? jumpHeightCustom : 550f;
    }
 
    private void OnTriggerEnter2D(Collider2D _collision) {
        if (_collision.gameObject.layer == LayerMask.NameToLayer("platform")) {
            m_rb.velocity = Vector2.zero;
            m_rb.AddForce(Vector2.up * JUMP_HEIGHT);
        }
    } 
}
