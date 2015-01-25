using UnityEngine;
using System.Collections;

public class CFL_FirstSignalPlatform : MonoBehaviour 
{
    GameObject platform;
    GameObject lever;


    void Start()
    {
        RaycastHit impact;

        if (Physics.Raycast(new Vector3(11.5f, 2, 15), new Vector3(0, 0, -1), out impact, 5))
            lever = impact.transform.parent.gameObject;

        // Spawn
        platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/Platform Signal/Platform Signal")) as GameObject;

        platform.transform.position = new Vector3(3f, 1f, 15f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = new Vector3(4.5f, 0.5f, 4);
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<SignalPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<SignalPlatformBehaviour>().endPosition = new Vector3(3f, 7.5f, 15f);
    }


    void Update()
    {
        if (lever.GetComponent<LeverBehaviour>().emiting)
            platform.transform.GetComponent<SignalPlatformBehaviour>().onSignal = true;
        else
            platform.transform.GetComponent<SignalPlatformBehaviour>().onSignal = false;
    }
}
