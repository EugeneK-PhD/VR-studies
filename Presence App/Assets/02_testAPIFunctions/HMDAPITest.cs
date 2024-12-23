// -----------------------------------------------------------------------
//
// (c) Copyright 1997-2017, SensoMotoric Instruments GmbH
// 
// Permission  is  hereby granted,  free  of  charge,  to any  person  or
// organization  obtaining  a  copy  of  the  software  and  accompanying
// documentation  covered  by  this  license  (the  "Software")  to  use,
// reproduce,  display, distribute, execute,  and transmit  the Software,
// and  to  prepare derivative  works  of  the  Software, and  to  permit
// third-parties to whom the Software  is furnished to do so, all subject
// to the following:
// 
// The  copyright notices  in  the Software  and  this entire  statement,
// including the above license  grant, this restriction and the following
// disclaimer, must be  included in all copies of  the Software, in whole
// or  in part, and  all derivative  works of  the Software,  unless such
// copies   or   derivative   works   are   solely   in   the   form   of
// machine-executable  object   code  generated  by   a  source  language
// processor.
// 
// THE  SOFTWARE IS  PROVIDED  "AS  IS", WITHOUT  WARRANTY  OF ANY  KIND,
// EXPRESS OR  IMPLIED, INCLUDING  BUT NOT LIMITED  TO THE  WARRANTIES OF
// MERCHANTABILITY,   FITNESS  FOR  A   PARTICULAR  PURPOSE,   TITLE  AND
// NON-INFRINGEMENT. IN  NO EVENT SHALL  THE COPYRIGHT HOLDERS  OR ANYONE
// DISTRIBUTING  THE  SOFTWARE  BE   LIABLE  FOR  ANY  DAMAGES  OR  OTHER
// LIABILITY, WHETHER  IN CONTRACT, TORT OR OTHERWISE,  ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE  SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
// -----------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

public class HMDAPITest : MonoBehaviour {

    SMI.SMIEyeTrackingUnity smiInstance = null;

    // Text mesh to display info
    public TextMesh GazeStream;
    public TextMesh LogStream;
    string logMessage = "";
    
    // Callback function for getting a calibration result
    void OnCalibrationResult(int returnCode)
    {
        Debug.Log("SMI HMD calibration result: " + SMI.SMIEyeTrackingUnity.ErrorIDContainer.getErrorMessage(returnCode));
        
        // Return code message:
        //     SMI_SUCCESS: Calibration is successfully done.
        //     SMI_OPERATION_FAILED: Calibration process is aborted.
        logMessage = "Calibration result:\n" + SMI.SMIEyeTrackingUnity.ErrorIDContainer.getErrorMessage(returnCode);
    }

    // Callback function for getting high frequency gaze sample. 
    // It is assured that all values within this callback are computed from the same timestamp images.
    void OnHighFrequencyGazeSample()
    {
        //ulong timeStamp = smiInstance.smi_GetTimeStamp();
        //Vector2 binocularPor = smiInstance.smi_GetBinocularPor();
        //Vector3 cameraRaycast = smiInstance.smi_GetCameraRaycast();
        //float ipd = smiInstance.smi_GetIPD();
        //Vector2 leftPor = smiInstance.smi_GetLeftPor();
        //Vector2 rightPor = smiInstance.smi_GetRightPor();
        //Vector3 leftBasePoint = smiInstance.smi_GetLeftGazeBase();
        //Vector3 rightBasePoint = smiInstance.smi_GetRightGazeBase();
        //Vector3 leftGazeDirection = smiInstance.smi_GetLeftGazeDirection();
        //Vector3 rightGazeDirection = smiInstance.smi_GetRightGazeDirection(); 
    }


    // Use this for initialization
    void Start ()
    {
        smiInstance = SMI.SMIEyeTrackingUnity.Instance;

        //To receive a calibration result, set a callback function
        smiInstance.smi_SetCalibrationReturnCallback(OnCalibrationResult);

        smiInstance.smi_SetAsyncGazeSampleCallback(OnHighFrequencyGazeSample); 
    }


    // Update is called once per frame
    void Update()
    {
        if (smiInstance == null)
            return;

        // 
        // Note that each get function delivers the value from the latest available gaze sample.
        // The gaze sample may be updated right after/before you call any of those get functions.
        // 
         
        ulong timeStamp = smiInstance.smi_GetTimeStamp();
        Vector2 binocularPor = smiInstance.smi_GetBinocularPor();
        Vector3 cameraRaycast = smiInstance.smi_GetCameraRaycast();
        float ipd = smiInstance.smi_GetIPD();
        Vector2 leftPor = smiInstance.smi_GetLeftPor();
        Vector2 rightPor = smiInstance.smi_GetRightPor();
        Vector3 leftBasePoint = smiInstance.smi_GetLeftGazeBase();
        Vector3 rightBasePoint = smiInstance.smi_GetRightGazeBase();
        Vector3 leftGazeDirection = smiInstance.smi_GetLeftGazeDirection();
        Vector3 rightGazeDirection = smiInstance.smi_GetRightGazeDirection();
        GazeStream.text =
            "sample:\t " + timeStamp + "\n" +
            "cameraRaycast:\n\t" + cameraRaycast.ToString("G4") + "\n" +
            "binocularPor:\n\t(" + binocularPor.x + ", "
                + binocularPor.y + ")" +
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(binocularPor) + "\n" +
            " ipd (m): " + ipd + 
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(ipd) + "\n"
            ;
        
        GazeStream.text +=
            "leftPor:\n\t(" + leftPor.x + ", "
                + leftPor.y + ")" +
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(leftPor) + "\n" +
            "rightPor:\n\t(" + rightPor.x + ", "
                + rightPor.y + ")" +
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(rightPor) + "\n"
            ;
        GazeStream.text +=
            "leftBasePoint (m):\n\t(" + leftBasePoint.x + ", "
                + leftBasePoint.y + ", " + leftBasePoint.z + ")" +
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(leftPor) + "\n" +
            "rightBasePoint (m):\n\t(" + rightBasePoint.x + ", "
                + rightBasePoint.y + ", " + rightBasePoint.z + ")" +
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(rightPor) + "\n"
            ;
        GazeStream.text +=
            "leftGazeDirection:\n\t(" + leftGazeDirection.x + ", "
                + leftGazeDirection.y + ", " + leftGazeDirection.z + ")" +
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(leftGazeDirection) + "\n" +
            "rightGazeDirection:\n\t(" + rightGazeDirection.x + ", "
                + rightGazeDirection.y + ", " + rightGazeDirection.z + ")" +
            "\tisValid: " + SMI.SMIEyeTrackingUnity.smi_IsValid(rightGazeDirection) + "\n"
            ;


        //Show gameobject in gaze focus
        TestGetGameObjectInFocus();

        LogStream.text = logMessage;
    }

    //Test calibration
    public void TestThreePointCalibration()
    {
        smiInstance.smi_StartThreePointCalibration();
    }
    
    //Test close validation
    public void TestCloseValidation()
    {
        smiInstance.smi_CloseVisualization();  
    }

    
    //Test get gameobject in focus
    public void TestGetGameObjectInFocus()
    {
        GameObject gameObj = smiInstance.smi_GetGazedObject();
        if (gameObj != null)
        {
            GazeStream.text += ("Gazed object: " + gameObj.name + "\n");

            //3D gaze point can be obtained from raycast
            RaycastHit gazeHit;
            if(smiInstance.smi_GetRaycastHitFromGaze(out gazeHit))
                GazeStream.text += ("3D gaze hit point in world space: \n    (" + gazeHit.point.x + ", " + gazeHit.point.y + ", " + gazeHit.point.z + ")\n");
        }
    }

    //Test reset calibration
    public void TestResetCalibration()
    {
        smiInstance.smi_ResetCalibration();
    }

    //Test quit application
    public void TestQuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //Test streaming start/stop
    bool isStreaming = true;
    public void TestToggleStreaming()
    {
        if (!isStreaming)
        {
            smiInstance.smi_StartStreaming();
            isStreaming = true;
        }
        else
        {
            smiInstance.smi_StopStreaming();
            isStreaming = false;
        }
    }
}
