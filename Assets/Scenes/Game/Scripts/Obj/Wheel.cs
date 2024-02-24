using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    public static Wheel I;
	public void Awake(){ I = this; }
    
    public GameObject lastPlatform;

    public List<GameObject> platJumped;
    
    void Start() {
        platJumped = new List<GameObject>();
    }

    public void OnTriggerEnter2D (Collider2D _collision){
        if (_collision.gameObject.layer == LayerMask.NameToLayer("platform")) {
            GameObject _go = _collision.gameObject;

            if (_go.transform.position.y > lastPlatform.transform.position.y 
                && !platJumped.Contains (_go)
                && gameObject.transform.position.y > _go.transform.position.y 
                
                ) {
                MG.I.add_rating ("Yeah", "Successful Jump!", 1);

                platJumped.Add (_go);
            }
        }
    }
}
