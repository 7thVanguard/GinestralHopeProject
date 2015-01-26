using UnityEngine;
using System.Collections;

public class CFL_ThirdConstantPlatform : MonoBehaviour 
{
    void Start()
    {
        GameObject platform = (GameObject)Instantiate(Resources.Load("Props/Geometry/Platform Constant/Platform Constant")) as GameObject;

        platform.transform.position = new Vector3(19f, 5.5f, 32f);
        platform.transform.eulerAngles = Vector3.zero;
        platform.transform.localScale = new Vector3(2, 0.5f, 2);
        platform.transform.parent = Global.world.creationsController.transform;

        platform.GetComponent<ConstantPlatformBehaviour>().initialPosition = platform.transform.position;
        platform.GetComponent<ConstantPlatformBehaviour>().endPosition = new Vector3(19f, 5.5f, 40f);
    }
}
