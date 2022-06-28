using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    void Start()
    {
        print(Screen.width);
        Screen.SetResolution(640, 640, true);
    }
}
