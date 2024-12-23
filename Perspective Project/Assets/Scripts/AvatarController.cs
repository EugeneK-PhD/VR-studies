using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapTransforms
{
    public Transform vrTarget;
    public Transform ikTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void VRMapping()
    {
        /*
        Tracking position offset:
        - for left hand = (-0.05, -0.03, 0.88)
        - for right hand = (-0.05, -0.03, 0.88)
        */
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class AvatarController : MonoBehaviour
{
    [SerializeField] private MapTransforms head;
    [SerializeField] private MapTransforms leftHand;
    [SerializeField] private MapTransforms rightHand;
    [SerializeField] private float turnSmoothness;
    [SerializeField] Transform ikHead;
    [SerializeField] Vector3 headBodyOffset;
    [SerializeField] public GameObject entireScene;
    public float thresh;


    void LateUpdate()
    {
        //transform.position = new Vector3(ikHead.position.x + headBodyOffset.x, ikHead.position.y + headBodyOffset.y, ikHead.position.z + headBodyOffset.z);
        // -0.9f for the rig
        // -2.69f for the scene
        Vector3 newPosition = ikHead.position + headBodyOffset;
        if (newPosition.y - entireScene.transform.position.y > -0.9f - (-2.69f) + thresh)
        {
            // add the offset to the scene (MAKE SURE SCENE IS NOT MARKED STATIC FOR LIGHTING)
            entireScene.transform.position = entireScene.transform.position + new Vector3(0f, 0.01f, 0f);
        }
        else if (newPosition.y - entireScene.transform.position.y < -0.9f - (-2.69f) - thresh)
        {
            // subtract the offset from the scene 
            entireScene.transform.position = entireScene.transform.position - new Vector3(0f, 0.01f, 0f);
        }
        transform.position = ikHead.position + headBodyOffset;
        transform.eulerAngles = new Vector3(0f, ikHead.eulerAngles.y, 0f);
        //transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(-ikHead.right, Vector3.up).normalized, Time.deltaTime * turnSmoothness);
        head.VRMapping();
        leftHand.VRMapping();
        rightHand.VRMapping();
    }

}
