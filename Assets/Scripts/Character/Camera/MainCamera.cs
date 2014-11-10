using UnityEngine;
using System.Collections;

public class MainCamera
{
    public GameObject cameraObj;
    public CharacterController controller;

    // Camera movement
    public Quaternion rotation;
    public Vector3 offset;
    public Vector3 direction;

    public float objectivePosition;
    public float interpolatedPosition;

    public float angleSight;


    public MainCamera()
    {
        Init();
    }


    private void Init()
    {
        //+ Main camera creation
        cameraObj = new GameObject();

        cameraObj.name = "MainCamera";
        cameraObj.tag = "MainCamera";

        // Camera components creation
        cameraObj.AddComponent<Camera>();
        controller = cameraObj.AddComponent<CharacterController>();
        cameraObj.AddComponent("UCamera");

        cameraObj.AddComponent("FlareLayer");
    }
}
