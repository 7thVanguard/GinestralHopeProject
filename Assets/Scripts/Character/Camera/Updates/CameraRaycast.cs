using UnityEngine;
using System.Collections;

public class CameraRaycast
{
    public static RaycastHit impact;


    public void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out impact, 300))
        {
            // Impact is static and is goind to be used in other scripts
        }
        else
            impact = new RaycastHit();
    }
}
