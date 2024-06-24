using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MultiTouchInputManager : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;

    private HashSet<int> activeTouches = new HashSet<int>();

    void Update()
    {
        Debug.Log ("111");
		Debug.Log("Touch Count: " + Input.touchCount);
		foreach (Touch touch in Input.touches)
        {
			Debug.Log ("222");
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
            // Handle left button pressed logic
        }
        else if (IsTouchingButton(touch, rightButton))
        {
            Debug.Log("Right button pressed");
            activeTouches.Add(touch.fingerId);
            // Handle right button pressed logic
        }
        else if (IsTouchingButton(touch, jumpButton))
        {
            Debug.Log("Jump button pressed");
            activeTouches.Add(touch.fingerId);
            // Handle jump button pressed logic
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
