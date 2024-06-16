using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN_Settings : MonoBehaviour {
    public static BTN_Settings I;
	public void Awake(){ I = this; }

	public bool pauseGameOnShow;

	public void show (){
		P_Settings.I.show (true);

		if (pauseGameOnShow) {
			Time.timeScale = 0f;
		}
	}
}