using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterScene : MonoBehaviour {

    public static MasterScene I;
    public void Awake(){ I = this; }

    public string curMainScene = "";

    public int LVL_COUNT;

    void Start(){
        LVL_COUNT = 10;
        PlayerPrefs.SetInt ("Tutorial", 0);
        PlayerPrefs.SetInt ("LvlCount", LVL_COUNT);

        setup_player_prefs ();

        add_scene ("_GlobalScripts");
        change_main_scene ("Menu");

        Application.targetFrameRate = 60;
    }

    void Update(){
        
    }

    private void setup_player_prefs (){
        if (PlayerPrefs.GetInt ("v.1.2") == 1) return;

        for (int i = 1; i < LVL_COUNT; i++){
            PlayerPrefs.SetInt($"Level{i}Stars", 0);
        }

        PlayerPrefs.SetInt("BGM", 1);
        PlayerPrefs.SetInt("SFX", 1);

        PlayerPrefs.SetInt ("v.1.2", 1);
    }

    public void change_main_scene (string _scene) {
        if (curMainScene != "") remove_scene (curMainScene);
        add_scene (_scene);
        curMainScene = _scene;
    }

    public void add_scene (string _scene){
        SceneManager.LoadScene (_scene, LoadSceneMode.Additive);
    }

    public void remove_scene (string _scene){
        SceneManager.UnloadSceneAsync (_scene);
    }

    public void switch_camera(string _cameraName) {
        Camera[] cameras = Camera.allCameras;
        foreach (Camera camera in cameras) {
            camera.enabled = false;
        }

        GameObject cameraObject = GameObject.Find(_cameraName);
        if (cameraObject != null) {
            Camera targetCamera = cameraObject.GetComponent<Camera>();
            if (targetCamera != null) {
                targetCamera.enabled = true;
            }
        }
    }
}
