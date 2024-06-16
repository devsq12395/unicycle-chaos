using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContAPI : MonoBehaviour {
    public static ContAPI I;
    public void Awake() { I = this; }

    public void show_ad_midroll () {
        GameDistribution.Instance.ShowAd();
    }
}
