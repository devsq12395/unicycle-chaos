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
        // Check if running on WebGL and not in the editor
        #if UNITY_WEBGL && !UNITY_EDITOR
            if (IsMobileDevice())
            {
                isMobile = true;
                Debug.Log("Running on a mobile device");
            }
            else
            {
                isMobile = false;
                Debug.Log("Running on a desktop device");
            }
        #else
            Debug.Log("Not running in WebGL or running in the editor");
            isMobile = false;
        #endif
    }

    bool IsMobileDevice()
    {
        // Check platform using Application.platform
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                return true;
            default:
                return false;
        }
    }
}
