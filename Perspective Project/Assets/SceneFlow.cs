using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class SceneFlow : MonoBehaviour
{

    /*public float FirstMessageStartTime = 30f;
    public float FirstMessageEndTime = 90f;
    public float SecondMessageStartTime = 150f;
    public float SecondMessageEndTime = 210f;
    */
    public TimelineAsset timeline;
    public GameObject firstMessage;
    public GameObject secondMessage;
    public GameObject NPC;
    public GameObject arrow;
    public Camera cam;
    public Plane[] planes;

    /*public float animationDuration = 1f;

    public GameObject firstMessageCanvas;
    public GameObject secondMessageCanvas;
    */
    // Start is called at the beginning 
    private void Start()
    {
        //firstMessageCanvas.SetActive(false);
        //secondMessageCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Time.time < FirstMessageStartTime)
        {
            // do nothing, just wait
        }
        else if (Time.time > FirstMessageStartTime && Time.time < FirstMessageEndTime)
        {
            // enable the canvas after the animation plays out
            if (Time.time >= FirstMessageStartTime + animationDuration)
            {
                firstMessageCanvas.SetActive(true);
            }
        }
        else if (Time.time > FirstMessageEndTime && Time.time < SecondMessageStartTime)
        {
            // disable the first message
            firstMessageCanvas.SetActive(false);
        }
        else if (Time.time > SecondMessageStartTime && Time.time < SecondMessageEndTime)
        {
            // enable the canvas after the animation plays out
            if (Time.time >= SecondMessageStartTime + animationDuration)
            {
                secondMessageCanvas.SetActive(true);
            }
        }
        else if (Time.time > SecondMessageEndTime && Time.time < SceneEndTime)
        {
            // disable the second message
            secondMessageCanvas.SetActive(false);
        }
        else*//* if (Time.time > SceneEndTime)
        {
            // end scene
            // different if playing in editor
            # if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            # else
                Application.Quit();
            # endif 
        }*/

        if (Time.time > timeline.duration)
        {
            // end scene 
            // different if playing in editor
            # if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            # else
            Application.Quit();
            # endif 
        }

        if (firstMessage.activeSelf == true || secondMessage.activeSelf == true)
        {
            // only show direction arrow when the message is being displayed
            // but also don't show it if the player is already looking at the NPC
            planes = GeometryUtility.CalculateFrustumPlanes(cam);
            if (GeometryUtility.TestPlanesAABB(planes, NPC.GetComponent<SkinnedMeshRenderer>().bounds))
            {
                arrow.SetActive(false);
            }
            else
            {
                arrow.SetActive(true);
            }
        }

        else
        {
            arrow.SetActive(false);
        }



        

    }

}
