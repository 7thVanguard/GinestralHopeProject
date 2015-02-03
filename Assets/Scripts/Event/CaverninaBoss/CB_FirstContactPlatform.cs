using UnityEngine;
using System.Collections;

public class CB_FirstContactPlatform : MonoBehaviour 
{
    void Start()
    {
        GameObject platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/Platform Contact/Platform Contact")) as GameObject;

        platform.transform.position = new Vector3(37f, 4f, 32f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = new Vector3(3, 0.5f, 3);
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<ContactPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<ContactPlatformBehaviour>().endPosition = new Vector3(37f, 8f, 32f);
    }
}
