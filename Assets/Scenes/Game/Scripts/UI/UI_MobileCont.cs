using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_MobileCont : MonoBehaviour {
	public static UI_MobileCont I;
    public void Awake(){ I = this; }
    
	public GameObject goLeftArr, goRightArr, goUpArr;

	public void check_buttons (){
		goLeftArr.SetActive (DeviceDetection.I.isMobile);
		goRightArr.SetActive (DeviceDetection.I.isMobile);
		goUpArr.SetActive (DeviceDetection.I.isMobile);
	}
}