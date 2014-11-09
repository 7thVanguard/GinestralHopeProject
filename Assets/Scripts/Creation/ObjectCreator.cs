using UnityEngine;
using System.Collections;

public static class ObjectCreator
{
    //public static void WorldSet(GameObject world)
    //{
        
    //}


    //public static GameObject PlayerCreation(World world)
    //{
    //    return player;
    //}


    public static GameObject CameraCreation()
    {

        // Camera
        GameObject mainCamera = new GameObject();

        mainCamera.name = "MainCamera";
        mainCamera.tag = "MainCamera";

        // Camera components creation
        mainCamera.AddComponent<Camera>();
        mainCamera.AddComponent<CharacterController>();
        mainCamera.AddComponent("UCamera");

        mainCamera.AddComponent("FlareLayer");

        return mainCamera;
    }


    public static void SunCreation(Flare sunFlare)
    {
        // Sun
        GameObject sun = new GameObject();

        sun.name = "Sun";

        // Set sun transforms
        sun.transform.position = Vector3.zero;
        sun.transform.eulerAngles = new Vector3(50, 30, 0);
        sun.transform.localScale = Vector3.one;


        // Light components creation
        sun.AddComponent<Light>();
        sun.AddComponent<LensFlare>();
        sun.AddComponent("ULightSystem");

        sun.light.type = LightType.Directional;
        sun.light.shadows = LightShadows.Hard;

        sun.GetComponent<LensFlare>().flare = sunFlare;
    }
}
