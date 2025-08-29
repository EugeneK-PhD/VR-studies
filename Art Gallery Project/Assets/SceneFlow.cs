using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SceneFlow : MonoBehaviour
{

    public GameObject finalMessage;
    public GameObject blackScreen;

    public bool sceneStarted;

    double startTime;

    private bool lowSettings = false;

    void Start()
    {
        sceneStarted = false;
        finalMessage.SetActive(false);
        blackScreen.SetActive(true);
        Time.timeScale = 0f;
        UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1.2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!sceneStarted)
        {
            // look for a keypress
            if (DetectPrimaryButtonPress())
            {
                sceneStarted = true;
                blackScreen.SetActive(false);
                Time.timeScale = 1f;
                startTime = Time.time;
                return;                
            }
        }

        else if (sceneStarted && Time.time - startTime > 1.0f)
        {
            if (DetectPrimaryButtonPress())
            {
                blackScreen.SetActive(true);
                finalMessage.SetActive(true);   
            }
            if (DetectTriggerPress())
            {
                lowSettings = !lowSettings;
                if (lowSettings)
                {
                    UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1.2f;
                }
                else
                {
                    UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 0.5f;
                }
            }
        }
    }

    bool DetectPrimaryButtonPress()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];
            bool buttonPress;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out buttonPress) && buttonPress)
            {
                return true;
            }
        }
        return false; 
    }

    bool DetectTriggerPress()
    {
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count == 1)
        {
            UnityEngine.XR.InputDevice device = rightHandDevices[0];
            bool triggerPress;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerPress) && triggerPress)
            {
                return true;
            }
        }
        return false;
    }
}
