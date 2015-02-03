using UnityEngine;
using System.Collections;

public class CB_FirstConstantPlatform : MonoBehaviour 
{
    void Start()
    {
        GameObject platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/Platform Constant/Platform Constant")) as GameObject;

        platform.transform.position = new Vector3(32f, 6.25f, 2.25f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = new Vector3(3, 0.5f, 3);
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<ConstantPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<ConstantPlatformBehaviour>().endPosition = new Vector3(22f, 6.25f, 2.25f);
    }
}
