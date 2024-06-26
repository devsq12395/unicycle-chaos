using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Tutorial : MonoBehaviour {
	public static UI_Tutorial I;
    public void Awake(){ I = this; }
    
	public TextMeshProUGUI txt;

	public void check_text (){
		if (DeviceDetection.I.isMobile) {
			txt.text = "Left/Right arrow - move left/right\nUp arrow - Jump";
		}
	}
}