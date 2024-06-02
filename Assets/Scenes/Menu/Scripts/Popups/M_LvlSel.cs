using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_LvlSel : MonoBehaviour {
    public static M_LvlSel I;
    public void Awake(){ I = this; }

    public GameObject panel;
    public GameObject levelButtonPrefab;
    public Sprite starEmpty, starFull;

    private Vector2 startPosition; 
    private Vector2 offset; 

    public void setup() {
        PopulateLevelSelect();
    }

    void PopulateLevelSelect() {
        int numberOfLevels = Menu.I.LVL_COUNT;
        startPosition = new Vector2(-182, 32);
        offset = new Vector2(94, -122); 
        int columns = 5;

        for (int i = 0; i < numberOfLevels; i++) {
            GameObject buttonInstance = Instantiate(levelButtonPrefab, panel.transform);

            LvlBtn levelButton = buttonInstance.GetComponent<LvlBtn>();
            levelButton.setup ();

            if (levelButton != null) {
                levelButton.SetLevel(i + 1, starEmpty, starFull);
            }

            int row = i / columns;
            int column = i % columns;
            buttonInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                startPosition.x + column * offset.x,
                startPosition.y + row * offset.y
            );
        }
    }

    public void Show() {
        panel.SetActive(true);
    }

    public void Hide() {
        panel.SetActive(false);
    }
}