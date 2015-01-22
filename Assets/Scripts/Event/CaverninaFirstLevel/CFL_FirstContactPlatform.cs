using UnityEngine;
using System.Collections;

public class CFL_FirstContactPlatform : MonoBehaviour 
{
	void Start () 
    {
        GameObject platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/ContactPlatform/ContactPlatform")) as GameObject;

        platform.transform.position = new Vector3(11.25f, 5.5f, 2.75f);
        platform.transform.eulerAngles = Vector3.zero;

        platform.GetComponent<ContactPlatformBehaviour>().initialPosition = new Vector3(11.25f, 5.5f, 2.75f);
        platform.GetComponent<ContactPlatformBehaviour>().endPosition = new Vector3(20.75f, 5.5f, 2.75f);
	}
}
