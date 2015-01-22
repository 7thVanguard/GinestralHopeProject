using UnityEngine;
using System.Collections;

public class CFL_FirstSignalPlatform : MonoBehaviour 
{
    GameObject platform;
    GameObject lever;


    void Start()
    {
        RaycastHit impact;

        if (Physics.Raycast(new Vector3(5.5f, 2, 15), new Vector3(0, 0, -1), out impact, 5))
            lever = impact.transform.parent.gameObject;

        // Spawn
        platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/SignalPlatform/SignalPlatform")) as GameObject;

        platform.transform.position = new Vector3(15.25f, 1f, 15f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = Vector3.one;

        platform.GetComponent<SignalPlatformBehaviour>().initialPosition = new Vector3(15.25f, 1f, 15f);
        platform.GetComponent<SignalPlatformBehaviour>().endPosition = new Vector3(15.25f, 7.5f, 15f);

        platform.GetComponent<SignalPlatformBehaviour>().signalEmitter = lever;
    }
}
