using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class ResetPosition : MonoBehaviour
{

    public Transform head;
    public Transform origin;
    public Transform target;
    public Transform TPP;
    public GameObject Sphere;
    public GameObject arrow;

    public GameObject TPPCam;

    public Vector3 TPPOffset;

    void Recenter()
    {
        Vector3 originOffset = head.position - origin.position;
        originOffset.y = 0;
        origin.position = target.position - originOffset;

        Vector3 targetForward = target.forward;
        targetForward.y = 0;
        Vector3 headForward = head.forward;
        headForward.y = 0;
        float angle = Vector3.SignedAngle(headForward, targetForward, Vector3.up);
        origin.RotateAround(head.position, Vector3.up, angle);
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        // make sure game is paused at beginning, wait for recenter to resume
        Time.timeScale = 0f;
        Application.targetFrameRate = 120;
        Sphere.SetActive(true);
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectPrimaryButtonPress())
        {
            Recenter();
            Sphere.SetActive(false);
            //arrow.SetActive(true);
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
}
