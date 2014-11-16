using UnityEngine;
using System.Collections;

public class CameraRaycast
{
    MainCamera mainCamera;


    public CameraRaycast(MainCamera mainCamera)
    {
        this.mainCamera = mainCamera;
    }


    public void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out mainCamera.raycast, 300)) { }
    }
}
