using UnityEngine;

public class WebGLTouchHandler : MonoBehaviour
{
    void Start()
    {
        #if UNITY_WEBGL
        WebGLInput.captureAllKeyboardInput = false;
        #endif
    }

    void Update()
    {
        #if UNITY_WEBGL
        HandleWebGLTouch();
        #endif
    }

    void HandleWebGLTouch()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Debug.Log("WebGL Touch Detected: " + touch.position);
                // Handle touch input similarly
            }
        }
    }
}
