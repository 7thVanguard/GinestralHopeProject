using UnityEngine;
using System.Collections;

public class EventsToolManager
{
    public static void Remove()
    {
        if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.CHANGECHUNKSIZE)
        {

        }
    }


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.EVENT)
        {
        Vector3 position;

            if (mainCamera.raycast.normal.y > 0.75f)
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, mainCamera.raycast.point.y + 0.5f, ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.y < -0.75f)
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, mainCamera.raycast.point.y - 0.5f, ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.x > 0.75f)
                position = new Vector3(mainCamera.raycast.point.x + 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.x < -0.75f)
                position = new Vector3(mainCamera.raycast.point.x - 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), ((int)mainCamera.raycast.point.z) + 0.5f);
            else if (mainCamera.raycast.normal.z > 0.75f)
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), mainCamera.raycast.point.z + 0.5f);
            else
                position = new Vector3(((int)mainCamera.raycast.point.x) + 0.5f, ((int)mainCamera.raycast.point.y + 0.5f), mainCamera.raycast.point.z - 0.5f);

            Event.Place(world, player, "none", position);
        }
        else if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.CHANGECHUNKSIZE)
        {
            if (mainCamera.raycast.point.x > (Global.world.chunkNumber.x - 1) * Global.world.chunkSize.x)
            {

            }
            else if (mainCamera.raycast.point.x < Global.world.chunkSize.x)
            {

            }
            else if (mainCamera.raycast.point.z > (Global.world.chunkNumber.z - 1) * Global.world.chunkSize.z)
            {

            }
            else if (mainCamera.raycast.point.z < Global.world.chunkSize.z)
            {

            }
        }
    }


    public static void Cancel()
    {
        
    }


    public static void Detect(World world, Player player, MainCamera mainCamera)
    {
        if (GameFlow.developerWorldTools == GameFlow.DeveloperWorldTools.CHANGECHUNKSIZE)
        {
            if (mainCamera.raycast.point.x > (Global.world.chunkNumber.x - 1) * Global.world.chunkSize.x)
            {
                HUD.cubeMarker.transform.position = new Vector3((Global.world.chunkNumber.x - 0.5f) * Global.world.chunkSize.x,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y / 2,
                                                                Global.world.chunkNumber.z * Global.world.chunkSize.z / 2);

                HUD.cubeMarker.transform.localScale = new Vector3(Global.world.chunkSize.x,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y,
                                                                Global.world.chunkNumber.z * Global.world.chunkSize.z);
            }
            else if (mainCamera.raycast.point.x < Global.world.chunkSize.x)
            {
                HUD.cubeMarker.transform.position = new Vector3(Global.world.chunkSize.x / 2,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y / 2,
                                                                Global.world.chunkNumber.z * Global.world.chunkSize.z / 2);

                HUD.cubeMarker.transform.localScale = new Vector3(Global.world.chunkSize.x,
                                                                 Global.world.chunkNumber.y * Global.world.chunkSize.y,
                                                                 Global.world.chunkNumber.z * Global.world.chunkSize.z);
            }
            else if (mainCamera.raycast.point.z > (Global.world.chunkNumber.z - 1) * Global.world.chunkSize.z)
            {
                HUD.cubeMarker.transform.position = new Vector3(Global.world.chunkNumber.x * Global.world.chunkSize.x / 2,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y / 2,
                                                                (Global.world.chunkNumber.z - 0.5f) * Global.world.chunkSize.z);

                HUD.cubeMarker.transform.localScale = new Vector3(Global.world.chunkNumber.x * Global.world.chunkSize.x,
                                                                 Global.world.chunkNumber.y * Global.world.chunkSize.y,
                                                                 Global.world.chunkSize.z);
            }
            else if (mainCamera.raycast.point.z < Global.world.chunkSize.z)
            {
                HUD.cubeMarker.transform.position = new Vector3(Global.world.chunkNumber.x * Global.world.chunkSize.x / 2,
                                                                Global.world.chunkNumber.y * Global.world.chunkSize.y / 2,
                                                                Global.world.chunkSize.z / 2);

                HUD.cubeMarker.transform.localScale = new Vector3(Global.world.chunkNumber.x * Global.world.chunkSize.x,
                                                                 Global.world.chunkNumber.y * Global.world.chunkSize.y,
                                                                 Global.world.chunkSize.z);
            }
            else
            {
                HUD.cubeMarker.transform.position = new Vector3(0, -10000, 0);
            }
        }
        else
        {

        }
    }
}
