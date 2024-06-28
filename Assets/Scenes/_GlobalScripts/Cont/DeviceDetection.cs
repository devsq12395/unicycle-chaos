using UnityEngine;

public class DeviceDetection : MonoBehaviour
{
    public static DeviceDetection I;
    public bool isMobile;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        isMobile = IsMobileDevice();
        Debug.Log(isMobile ? "Running on a mobile device" : "Running on a desktop device");
#else
        Debug.Log("Not running in WebGL or running in the editor");
        isMobile = false;
#endif
    }

    bool IsMobileDevice()
    {
        // Basic screen size check (can be adjusted as needed)
        // Typically, mobile devices have smaller screen sizes
        if (Screen.width <= 1024 || Screen.height <= 768)
        {
            return true;
        }

        // Further checks could include specific aspect ratio checks if needed
        return false;
    }
}
