using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultiTouchInputManager : MonoBehaviour {
    public static MultiTouchInputManager I;
    public void Awake(){ I = this; }
    
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;

    private HashSet<int> activeTouches = new HashSet<int>();

    private Char character;

    void Start()
    {
        character = Char.I;
        if (character == null)
        {
            Debug.LogError("Char script is not found.");
        }
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                CheckButtonTouch(touch);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                activeTouches.Remove(touch.fingerId);
            }
        }
    }

    void CheckButtonTouch(Touch touch)
    {
        if (IsTouchingButton(touch, leftButton))
        {
            Debug.Log("Left button pressed");
            activeTouches.Add(touch.fingerId);
            character.MoveLeft(); // Call the method to move the character left
        }
        else if (IsTouchingButton(touch, rightButton))
        {
            Debug.Log("Right button pressed");
            activeTouches.Add(touch.fingerId);
            character.MoveRight(); // Call the method to move the character right
        }
        else if (IsTouchingButton(touch, jumpButton))
        {
            Debug.Log("Jump button pressed");
            activeTouches.Add(touch.fingerId);
            character.Jump(); // Call the method to make the character jump
        }
    }

    bool IsTouchingButton(Touch touch, Button button)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = touch.position;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        foreach (RaycastResult result in raycastResults)
        {
            if (result.gameObject == button.gameObject)
            {
                return true;
            }
        }

        return false;
    }
}
