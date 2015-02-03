using UnityEngine;
using System.Collections;

public class CB_SecondConstantPlatform : MonoBehaviour 
{
    void Start()
    {
        GameObject platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/Platform Constant/Platform Constant")) as GameObject;

        platform.transform.position = new Vector3(7f, 6.25f, 2.25f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = new Vector3(3, 0.5f, 3);
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<ConstantPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<ConstantPlatformBehaviour>().endPosition = new Vector3(17f, 6.25f, 2.25f);
    }
}
