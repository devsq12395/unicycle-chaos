using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour {
    public static Char I;
	public void Awake(){ I = this; }
    
    public GameObject wheel;
    public AudioSource whlSoundSource;

    public Rigidbody2D wRb, cRb;

    public Vector2 wheelMov;
    public float balance, charAng, charAngVel;

    public bool isOnAir;

    private float backToStart_delay = 0;

    private float POW, DISTANCE_FROM_WHEEL, CHAR_FALL_SPEED, MAX_ANG_VEL, JUMP_FORCE;
    private Vector2 CHAR_OFFSET, MAX_VEL, START_POINT_WHEEL;
    private bool X_MOVE_CHECK_IF_ON_GROUND;
    
    void Start() {
        START_POINT_WHEEL = new Vector2 (-4.2f, -0.8f);
        POW = 0.5f;
        DISTANCE_FROM_WHEEL = 1f;
        CHAR_FALL_SPEED = 1f;
        CHAR_OFFSET = new Vector2 (0, 1f);
        JUMP_FORCE = 7f;
        
        charAng = 0;

        MAX_VEL = new Vector2 (4f, 1);
        MAX_ANG_VEL = 1f;

        X_MOVE_CHECK_IF_ON_GROUND = false;

        cRb = gameObject.GetComponent <Rigidbody2D>();
        wRb = wheel.GetComponent <Rigidbody2D>();
    }

    public void OnTriggerEnter2D (Collider2D _collision){ 
        if (_collision.gameObject.layer == LayerMask.NameToLayer("platform")) {
            MG.I.add_rating ("Boo", "Platform Hit!", 1);
        }
    }

    void Update (){
        back_to_start_w_delay_update ();

        if (MG.I.isPaused) return;

        input_move ();
        attach_char ();

        detect_if_fall ();
    }

    public void input_move (){
        wheelMov.x = Input.GetAxis("Horizontal");

        float applyX = 0, applyY = 0;
        
        // Calc X velocity
        if ((char_is_on_land () && wRb.velocity.y == 0) || !X_MOVE_CHECK_IF_ON_GROUND) {
            float wPow = POW * wheelMov.x;
            
            if (wPow > 0) {
                applyX = (wRb.velocity.x < MAX_VEL.x) ? wPow : 0;
            } else if (wPow < 0) {
                applyX = (wRb.velocity.x > -MAX_VEL.x) ? wPow : 0;
            }
        }

        // Calc Y velocity
        if (char_is_on_land () && wRb.velocity.y == 0) {
            if (Input.GetButtonDown("Vertical")) {
                applyY = JUMP_FORCE;
                ContSounds.I.play ("jump");
            }
        }

        wRb.velocity += new Vector2(applyX, applyY);

        if (wRb.velocity.x != 0 && char_is_on_land ()) {
            if (!whlSoundSource.isPlaying) {
                whlSoundSource.Play ();
            }
        } else {
            whlSoundSource.Stop ();
        }
    }

    private void attach_char (){
        if (char_is_on_land ()) {
            charAngVel = Mathf.Clamp(charAngVel - wRb.velocity.x / 5, -MAX_ANG_VEL, MAX_ANG_VEL);

            if (Mathf.Abs (wRb.velocity.x) < 3.5f) {
                charAng += charAngVel;
            } else {
                charAng += charAngVel / 3;
            }
        }

        Vector2 _offset = Calc.I.get_pos_on_dist (wRb.position, charAng + 90, DISTANCE_FROM_WHEEL);
        cRb.transform.position = _offset;
        cRb.transform.rotation = Quaternion.Euler (0, 0, charAng);
    }

    private bool char_is_on_land (){
        float DIST_CHECK = 1f;
        Vector2 _down = new Vector2(wRb.transform.position.x, wRb.transform.position.y - DIST_CHECK);
        RaycastHit2D hit = Physics2D.Linecast(wRb.transform.position, _down, LayerMask.GetMask("platform"));

        Debug.DrawLine(wRb.transform.position, _down, Color.red);

        return hit.collider != null;
    }

    private void detect_if_fall (){
        if (cRb.position.y <= -15f) { Debug.Log (cRb.position.y);
            MG.I.add_rating ("Boo", "Obstacle Hit!", 1);
        }
    }

    public void back_to_start_w_delay (float _delay) {
        backToStart_delay = _delay;
    }

    private void back_to_start_w_delay_update () {
        if (backToStart_delay > 0) {
            backToStart_delay -= Time.deltaTime;

            if (backToStart_delay <= 0) {
                backToStart_delay = 0;

                MG.I.resume_game ();
                back_to_start ();
            }
        }
    }

    public void back_to_start (){
        wRb.position = START_POINT_WHEEL;

        charAng = 0f;
        charAngVel = 0f;
        wRb.velocity = Vector2.zero;
        cRb.velocity = Vector2.zero;
    }
}
