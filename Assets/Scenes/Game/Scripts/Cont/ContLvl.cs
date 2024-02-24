using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContLvl : MonoBehaviour {    

    public static ContLvl I;
	public void Awake(){ I = this; }

    public List<GameObject> lvls;

    public void create_lvl (){
        
    }
    
}
