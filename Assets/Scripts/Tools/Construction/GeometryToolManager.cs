using UnityEngine;
using System.Collections;

public class GeometryToolManager
{
    public static void Remove(Player player, MainCamera mainCamera)
    {
        // Picks back the gadget
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.distance) && mainCamera.raycast.distance != 0)
            if (mainCamera.raycast.transform.gameObject.tag == "Geometry")
                Object.Destroy(mainCamera.raycast.transform.gameObject);
    }


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        Geometry.Place("none", mainCamera.raycast.point, Vector3.zero, Vector3.one);
    }


    public static void Cancel()
    {

    }


    public static void Detect(World world, Player player, MainCamera mainCamera)
    {

    }
}
