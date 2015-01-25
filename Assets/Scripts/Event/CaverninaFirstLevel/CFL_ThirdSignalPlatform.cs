using UnityEngine;
using System.Collections;

public class CFL_ThirdSignalPlatform : MonoBehaviour 
{
    GameObject platform;
    GameObject lever;


    void Start()
    {
        RaycastHit impact;

        if (Physics.Raycast(new Vector3(11f, 14, 22), new Vector3(0, 0, -1), out impact, 5))
            lever = impact.transform.parent.gameObject;

        // Spawn
        platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/SignalPlatform/SignalPlatform")) as GameObject;

        platform.transform.position = new Vector3(13.5f, 14.75f, 19.5f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = new Vector3(4f, 4f, 0.49f);
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<SignalPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<SignalPlatformBehaviour>().endPosition = new Vector3(13.5f, 14.75f, 13f);
    }


    void Update()
    {
        if (lever.GetComponent<LeverBehaviour>().emiting)
            platform.transform.GetComponent<SignalPlatformBehaviour>().onSignal = true;
        else
            platform.transform.GetComponent<SignalPlatformBehaviour>().onSignal = false;
    }
}
