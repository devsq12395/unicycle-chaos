using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calc : MonoBehaviour {

    public static Calc I;
	public void Awake(){ I = this; }

    public Vector2 get_pos_on_dist (Vector2 _pos, float _ang, float _dist){
        float _x = _pos.x + _dist * Mathf.Cos(_ang * Mathf.Deg2Rad);
        float _y = _pos.y + _dist * Mathf.Sin(_ang * Mathf.Deg2Rad);

        return new Vector2(_x, _y);
    }

    public float get_ang_from_2_points_deg (Vector2 _p1, Vector2 _p2){
        Vector2 _dir = _p2 - _p1;
        return Mathf.Atan2 (_dir.y, _dir.x) * Mathf.Rad2Deg;
    }

    
}
