using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void LoadAScene(int level)
    {
        Application.LoadLevel(level);
    }
}
