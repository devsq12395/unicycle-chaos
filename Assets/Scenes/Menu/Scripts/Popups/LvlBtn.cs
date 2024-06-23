using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LvlBtn : MonoBehaviour {
    public int lvl;
    public TextMeshProUGUI levelText;
    public List<Image> stars;

    public void setup (){
        stars = new List<Image>();
        for (int s = 1; s <= 3; s++){
            stars.Add (transform.Find ("Star"+s.ToString()).GetComponent<Image>());
        }
    }

    public void SetLevel(int level, Sprite starEmpty, Sprite starFull) {
        lvl = level;
        levelText.text = level.ToString();

        int starCount = PlayerPrefs.GetInt("Level" + level + "Stars", 0);
        for (int i = 0; i < stars.Count; i++) {
            stars[i].sprite = i < starCount ? starFull : starEmpty;
            stars[i].enabled = true;
        }
    }

    public void OnClick() {
        ContSounds.I.play ("click");
        ContAPI.I.show_ad_midroll ();
        Menu.I.go_to_game_lvl (lvl);
    }
}
