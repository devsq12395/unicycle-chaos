using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LvlDetails : MonoBehaviour {
	public static LvlDetails I;
    public void Awake() { I = this; }
    
	public Dictionary<int, int> starReqTimes;
}