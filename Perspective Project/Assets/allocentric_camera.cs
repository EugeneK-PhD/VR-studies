using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allocentric_camera : MonoBehaviour
{
    /*
     * The idea for this script is to create something that you can just pluck and paste onto any camera in Unity, and it will behave like a tracked allocentric camera.
     * For this, we assume the following:
     * - IK is used to rig the avatar
     * - There are virtual controller and HMD objects mapped to the exact location of the head and hands of the avatar (with no offset gymnastics)
     * 
     * This script simply takes the orientation of the tracked HMD and applies it locally to the TPP camera
     */
    public Vector3 cameraOffset;
    public Transform HMDCamera;
    public Transform origin;

    private void Update()
    {
        transform.position = HMDCamera.position + cameraOffset;
        transform.rotation = HMDCamera.rotation;
        //transform.eulerAngles = HMDCamera.eulerAngles;
        //transform.forward = origin.forward;
        //transform.forward = HMDCamera.transform.forward;
    }
}
