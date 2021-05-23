using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public string LaunchParameters = "Main";

    public float PitchAngle = 60.0f;
    public float Zoom = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        Program.Instance.Launch(LaunchParameters);
        Boss.Instance.Launch(LaunchParameters);
        Factory.Instance.Launch(LaunchParameters);
        
        Camera mainCamera = Camera.main;
        mainCamera.transform.rotation = Quaternion.Euler(PitchAngle,0.0f,0.0f);
        float yPos = Mathf.Sin(PitchAngle*Mathf.Deg2Rad)*Zoom;
        float zPos = Mathf.Cos(PitchAngle*Mathf.Deg2Rad)*Zoom;
        mainCamera.transform.position = new Vector3(0, yPos, -zPos);
    }

}
