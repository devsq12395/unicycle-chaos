using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MG : MonoBehaviour {
    public static MG I;
	public void Awake(){ I = this; }

    public struct Rating{
        public string type, desc;
        public int score;

        public Rating(string _t, string _d, int _s){
            type = _t;
            desc = _d;
            score = _s;
        }
    };

    public List<Rating> ratings;

    public bool isPaused, isGameOver;

    public int lvlNum;
    public float timer, booCd, BOO_CD_DEF;

    void Start() {
        BOO_CD_DEF = 0.2f;

        ratings = new List<Rating> ();

        if (PlayerPrefs.GetInt ("Tutorial") == 0) {
            UI_Main.I.goTut.SetActive (true);
            PlayerPrefs.SetInt ("Tutorial", 1);
            pause_game ();
        }

        lvlNum = PlayerPrefs.GetInt ("Lvl");
        ContLvl.I.create_lvl ();
    }

    void Update (){
        if (isPaused) return;

        game_timer ();
        boo_cd ();
    }

    public void add_rating (string _t, string _d, int _s){
        if (_t == "Boo"){
            if (booCd > 0) return;

            pause_game ();
            Char.I.back_to_start_w_delay (0.7f);

            ratings.Add (new Rating (_t, _d, _s));
            UI_Announce.I.create_announce (_t);

            booCd = BOO_CD_DEF;
        } else {
            ratings.Add (new Rating (_t, _d, _s));
            UI_Announce.I.create_announce (_t);
        }
    }

    public int get_val (string _t){
        int _ret = 0;
        foreach (Rating _r in ratings) {
            if (_r.type == _t) _ret += _r.score;
        }
        return _ret;
    }

    public void game_over (){
        pause_game ();
        UI_GameOver.I.show (false);
    }

    public void pause_game (){
        Rigidbody2D[] rigidbodies = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D rb in rigidbodies) { 
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            rb.isKinematic = true;
        }
        isPaused = true;
    }

    public void resume_game (){
        Rigidbody2D[] rigidbodies = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D rb in rigidbodies) {
            if (rb.CompareTag("kinematic")) {
                continue;
            }

            rb.isKinematic = false;
        }
        isPaused = false;
    }

    private void game_timer (){
        if (isPaused || Char.I.wRb.velocity.x == 0) return;
        timer += Time.deltaTime;
    }

    private void boo_cd (){
        if (booCd > 0) {
            booCd -= Time.deltaTime;

            if (booCd < 0) booCd = 0;
        }
    }

    public void change_scene (string _scene){
        //SceneManager.LoadScene(_scene, LoadSceneMode.Single);
        MasterScene.I.change_main_scene (_scene);
    }
}
