using UnityEngine;
using System.Collections;

public class CFL_FirstContactPlatform : MonoBehaviour 
{
	void Start ()
    {
        GameObject platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/Platform Contact/Platform Contact")) as GameObject;

        platform.transform.position = new Vector3(11.25f, 5.5f, 2.75f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<ContactPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<ContactPlatformBehaviour>().endPosition = new Vector3(20.75f, 5.5f, 2.75f);
	}
}
