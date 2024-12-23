using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtNPC : MonoBehaviour
{

    public GameObject NPC;

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtPosition = new Vector3(NPC.transform.position.x, transform.position.y, NPC.transform.position.z); 
        transform.LookAt(lookAtPosition);
    }
}
