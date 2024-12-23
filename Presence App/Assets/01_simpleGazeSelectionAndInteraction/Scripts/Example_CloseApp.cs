using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_CloseApp : MonoBehaviour
{

    public KeyCode CloseShortcut = KeyCode.Escape;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(CloseShortcut))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
