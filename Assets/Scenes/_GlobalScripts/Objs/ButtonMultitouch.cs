using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class ButtonMultitouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public enum ButtonType { Left, Right, Jump }; // Define button types
    public ButtonType buttonType; // Assign this button a specific type

    private Dictionary<int, ButtonType> pressedButtons; // Dictionary to track active touches and their button types

    private void Start()
    {
        pressedButtons = new Dictionary<int, ButtonType>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int touchId = eventData.pointerId; // Get the touch ID

        // Check if this touch is already registered
        if (!pressedButtons.ContainsKey(touchId))
        {
            pressedButtons.Add(touchId, buttonType); // Add touch and button type
            TriggerButtonPress(buttonType, true); // Trigger press for this button type
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        int touchId = eventData.pointerId;

        // Check if the touch ID exists and remove it
        if (pressedButtons.ContainsKey(touchId))
        {
            ButtonType buttonType = pressedButtons[touchId];
            pressedButtons.Remove(touchId);
            TriggerButtonPress(buttonType, false); // Trigger release for this button type

            // Check if any touches remain after releasing this touch
            if (pressedButtons.Count == 0)
            {
                // All buttons released, trigger global release event (optional)
                TriggerAllButtonsReleased();
            }
        }
    }

    private void TriggerButtonPress(ButtonType buttonType, bool isPressed)
    {
        // Implement your logic to handle button press/release events based on buttonType and isPressed
        Debug.Log($"Button {buttonType} {(isPressed ? "Pressed" : "Released")}");
    }

    private void TriggerAllButtonsReleased()
    {
        // Implement your logic for when all buttons are released (optional)
        Debug.Log("All Buttons Released!");
    }
}
