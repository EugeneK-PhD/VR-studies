using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtCamera : MonoBehaviour
{
    
    public Transform cameraPosition;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraPosition);
        transform.RotateAround(transform.position, Vector3.up, 180);
    }
}
