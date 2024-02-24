using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_GameOver : MonoBehaviour {
    public static UI_GameOver I;
    public void Awake() { I = this; }

    public GameObject go;

    public TextMeshProUGUI t_desc;

    public void show (){
        go.SetActive (true);

        MG.I.isGameOver = true;
        MG.I.pause_game ();

        int _boos = MG.I.get_val ("Boo"),
            _yeah = MG.I.get_val ("Yeah"),
            _total = _yeah - _boos;

        t_desc.text = "Total Boos: " + _boos + "\nTotal Yeahs: " + _yeah + "\n\nAudience Reaction:\n" + get_audience_response (_total);

        ContSounds.I.play (((_total <= 10) ? "bad" : "good"));
    }

    private string get_audience_response(int _total) {
        Dictionary<int, string[]> _responses = new Dictionary<int, string[]>() {
            { 0, new string[] {
                "Boo! Try harder next time!",
                "They're throwing tomatoes at you!",
                "I wasted my money on this circus!"
            }},
            { 5, new string[] {
                "Not bad. Just meh.",
                "I think some audience fell asleep.",
                "Some of them just walked out lol."
            }},
            { 10, new string[] {
                "Mixed reactions! Keep practicing!",
                "The audience is intrigued, show them more!",
                "A decent performance, but aim for greatness!"
            }},
            { 15, new string[] {
                "Standing ovation! You're a circus legend!",
                "You're like a rockstar!",
                "You're winning hearts with your performance!"
            }}
        };

        foreach (var _kvp in _responses) {
            if (_total <= _kvp.Key) {
                int index = UnityEngine.Random.Range(0, _kvp.Value.Length);
                return _kvp.Value[index];
            }
        }

        return "Standing ovation! You're a circus legend!";
    }

    public void btn_try_again (){
        MG.I.change_scene ("Game");
    }
}
