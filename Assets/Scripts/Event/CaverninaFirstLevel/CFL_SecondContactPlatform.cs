using UnityEngine;
using System.Collections;

public class CFL_SecondContactPlatform : MonoBehaviour 
{
    void Start()
    {
        GameObject platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/Platform Contact/Platform Contact")) as GameObject;

        platform.transform.position = new Vector3(15f, 1f, 15);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = new Vector3(4.5f, 0.5f, 4);
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<ContactPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<ContactPlatformBehaviour>().endPosition = new Vector3(15f, 7.5f, 15);
    }
}
