using UnityEngine;
using System.Collections;

public class EventsToolManager
{
    public static void Place(World world, Player player, MainCamera mainCamera)
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
}
