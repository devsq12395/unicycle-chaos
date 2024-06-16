using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContCanvas : MonoBehaviour {
    public static ContCanvas I;
    public Canvas canvas;

    public void Awake() {
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    public void set_main_camera() {
        Camera mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (mainCamera != null) {
            canvas.worldCamera = mainCamera;
        } else {
            Debug.LogWarning("Main Camera not found in the current scene.");
        }
    }
}
