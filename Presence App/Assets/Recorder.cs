using SMI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UDPMan;

public class Recorder : MonoBehaviour
{

    StreamWriter EyeRec, VRRec;
    SMI.SMIEyeTrackingUnity smiInstance = null;
    public string path;
    public string objectGaze = "None";
    public bool predicatable;
    public bool fallscene = false;
    public int fallscenelength;
    public bool stillpaused = true;
    public PlayableDirector pd;
    public FloorTiles FTScript;
    public GameObject body;
    public GameObject head;
    public UDPReceiver udp;
    public Camera camera;

    public void openStreams()
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.Log("Created " + path);
        }
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.Log("Created " + path);

        }
        VRRec = File.CreateText(path + "/" + "SessionVR.txt");
        EyeRec = File.CreateText(path + "/" + "SessionEye.txt");

    }

    // Start is called before the first frame update
    void Start()
    {
        path = "C:/eugeneData/" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "";
        smiInstance = SMIEyeTrackingUnity.Instance;
        StartCoroutine(beginRecording());
        body.transform.position = new Vector3(5.199f, 12.75f - UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye).y, 0.029f);
        udp = new UDPReceiver();
        udp.init();
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (smiInstance.smi_GetGazedObject() != null)
            {
                objectGaze = smiInstance.smi_GetGazedObject().name;
            }
            else
            {
                objectGaze = "None";
            }
        }
        catch(Exception ex)
        {
            objectGaze = "Error";
        }
        if (stillpaused)
        {
            pd.time = 5;
        }
        //if (Input.GetKeyDown(KeyCode.P))
        if (udp.seeLast() == "B" || Input.GetKeyDown(KeyCode.B))
        {
            udp.clear();
            stillpaused = false;
            pd.Play();
           if (!fallscene) StartCoroutine(FTScript.fallingTiles()); //starts the coroutine to start dropping tiles
           if (fallscene) StartCoroutine(FTScript.finalFall());
            //  StartCoroutine(FTScript.movingWalls()); //starts the coroutine to start moving walls
            //  StartCoroutine(FTScript.fallingCeiling()); //starts the coroutine to start moving ceiling
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            body.transform.position = new Vector3(5.199f, 12.75f - UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye).y, 0.029f);
        }
    }


    public Vector3 getrot()
    {
        return UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye).eulerAngles;
    }

    public Vector3 getpos()
    {
        return UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
    }

    private bool ICanSee(GameObject objectx)
    {
        try
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(planes, objectx.GetComponent<Collider>().bounds);
        } catch
        {
            return false;
        }
    }

    IEnumerator beginRecording()
    {
        while (stillpaused)
        {
            yield return null;
        }
        float timestart = Time.time;
        openStreams();
        VRRec.WriteLine("Pitch,Yaw,Roll,MST,Time,AP,VERTICAL,ML,ActiveObject,GazedObject,ObjectInView");
        EyeRec.WriteLine("BinocPorX,BinocPorY,LeftPorX,LeftPorY,RightPorX,RightPorY,IPD,LeftGazeBaseX,LeftGazeBaseY,LeftGazeBaseZ,RightGazeBaseX,RightGazeBaseY,RightGazeBaseZ,LPupilRadius,RPupilRadius,LGazeDirX,LGazeDirY,LGazeDirZ,RGazeDirX,RGazeDirY,RGazeDirZ,MS,Time");
        
        while (true)
        {
            float timestamp = Time.time - timestart;
            double timestamptoa = System.DateTime.Now.ToOADate();
            Vector3 VRRot = getrot();
            Vector3 VRPos = getpos();
            Vector3 GazeLeft = new Vector3(-1, -1, -1);
            Vector3 GazeRight = new Vector3(-1, -1, -1);
            try
            {
                GazeLeft = smiInstance.smi_GetLeftGazeBase();
                GazeRight = smiInstance.smi_GetRightGazeBase();
            } catch (Exception ex)
            {

            }
            //Debug.Log(VRPos.x + "/" + VRPos.y + "/" + VRPos.z + " - " + VRRot.x + "/" + VRRot.y + "/" + VRRot.z);

            VRRec.Write((VRRot.x + 180) % 360 + "," + (VRRot.y + 180) % 360 + "," + (VRRot.z + 180) % 360 + "," + timestamp + "," + timestamptoa + "," + VRPos.x + "," + VRPos.y + "," + VRPos.z);
            if (predicatable)
            {
                float x = Time.time - timestart;
                string obj = "None";
                if ((x >= 76 && x <= 85))
                {
                    obj = "Wall3";
                    if (ICanSee(GameObject.Find("Wall (3)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 89 && x <= 99))
                {
                    obj = "Wall11";
                    if (ICanSee(GameObject.Find("Wall (11)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 100 && x <= 108))
                {
                    obj = "Wall2";
                    if (ICanSee(GameObject.Find("Wall (2)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 124 && x <= 133))
                {
                    obj = "Wall10";
                    if (ICanSee(GameObject.Find("Wall (10)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 140 && x <= 148))
                {
                    obj = "Ceiling5";
                    if (ICanSee(GameObject.Find("Ceiling (5)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 153 && x <= 161))
                {
                    obj = "Ceiling6";
                    if (ICanSee(GameObject.Find("Ceiling (6)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 173 && x <= 181))
                {
                    obj = "Wall1";
                    if (ICanSee(GameObject.Find("Wall (1)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 189 && x <= 198))
                {
                    obj = "Wall9";
                    if (ICanSee(GameObject.Find("Wall (9)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else objectGaze += ",NA";
                VRRec.Write("," + obj);
            }
            else
            {
                float x = Time.time - timestart;
                string obj = "None";
                if ((x >= 36 && x <= 44))
                {
                    obj = "Wall1";
                    if (ICanSee(GameObject.Find("Wall (1)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 48 && x <= 59))
                {
                    obj = "Ceiling5";
                    if (ICanSee(GameObject.Find("Ceiling (5)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 71 && x <= 79))
                {
                    obj = "Wall9";
                    if (ICanSee(GameObject.Find("Wall (9)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 92 && x <= 101))
                {
                    obj = "Wall10";
                    if (ICanSee(GameObject.Find("Wall (10)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 106 && x <= 114))
                {
                    obj = "Ceiling6";
                    if (ICanSee(GameObject.Find("Ceiling (6))")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 144 && x <= 153))
                {
                    obj = "Wall2";
                    if (ICanSee(GameObject.Find("Wall (2)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 171 && x <= 180))
                {
                    obj = "Wall3";
                    if (ICanSee(GameObject.Find("Wall (3)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                else if ((x >= 190 && x <= 200))
                {
                    obj = "Wall11";
                    if (ICanSee(GameObject.Find("Wall (11)")))
                        objectGaze += ",true";
                    else
                        objectGaze += ",false";
                }
                    else objectGaze += ",NA";
                VRRec.Write("," + obj);
            }
          //  objectGaze.Replace(",", "");

            VRRec.WriteLine("," + objectGaze);

            
            EyeRec.WriteLine(smiInstance.smi_GetBinocularPor().x.ToString() + "," + smiInstance.smi_GetBinocularPor().y.ToString() + ","
                + smiInstance.smi_GetLeftPor().x + "," + smiInstance.smi_GetLeftPor().y + "," + smiInstance.smi_GetRightPor().x + "," + smiInstance.smi_GetRightPor().y + ","
                + smiInstance.smi_GetIPD().ToString() + ","
                + GazeLeft.x.ToString() + "," + GazeLeft.y.ToString() + "," + GazeLeft.z.ToString() + ","
                + GazeRight.x.ToString() + "," + GazeRight.y.ToString() + "," + GazeRight.z.ToString() + ","
                + smiInstance.smi_GetLeftPupilRadius().ToString() + "," + smiInstance.smi_GetRightPupilRadius().ToString() + ","
                + smiInstance.smi_GetLeftGazeDirection().x.ToString() + "," + smiInstance.smi_GetLeftGazeDirection().y.ToString() + "," + smiInstance.smi_GetLeftGazeDirection().z.ToString() + ","
                + smiInstance.smi_GetRightGazeDirection().x.ToString() + "," + smiInstance.smi_GetRightGazeDirection().y.ToString() + "," + smiInstance.smi_GetRightGazeDirection().z.ToString() + ","
                + timestamp + "," + timestamptoa);

            VRRec.Flush();
            EyeRec.Flush();
            yield return null;
            if (Time.time - timestart >= 230)
            {
                VRRec.Close();
                EyeRec.Close();
                Application.Quit();
            }
            if (fallscene)
            {
                if (Time.time - timestart >= 60)
                {
                    VRRec.Close();
                    EyeRec.Close();
                    Application.Quit();
                }
            }
        }

    }
}
