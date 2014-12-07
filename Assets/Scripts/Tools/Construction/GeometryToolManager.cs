using UnityEngine;
using System.Collections;

public class GeometryToolManager
{
    public static void Remove(Player player, MainCamera mainCamera)
    {
        // Picks back the gadget
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
            if (mainCamera.raycast.transform.gameObject.tag == "Geometry")
                Object.Destroy(mainCamera.raycast.transform.gameObject);
    }


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
        {
            //+ Floor
            if (mainCamera.raycast.normal.y >= 0.75f && Geometry.Dictionary[EGameFlow.selectedGeometry].placedOn == Geometry.PlacedOn.FLOOR)
            {
                // Claculates the initial position and the rotation of the Gadget we are going to place
                int yRotation = (int)player.playerObj.transform.eulerAngles.y;

                Geometry.Dictionary[EGameFlow.selectedGeometry].Place(EGameFlow.selectedGeometry, mainCamera.raycast.point, 
                    new Vector3(0, yRotation, 0), Vector3.one, true);
            }
            //+ Wall
            else if (mainCamera.raycast.normal.y == 0 && Geometry.Dictionary[EGameFlow.selectedGeometry].placedOn == Geometry.PlacedOn.WALL)
            {
                int yRotation;

                if (mainCamera.raycast.normal == Vector3.back)
                {
                    yRotation = 0;
                    Geometry.Dictionary[EGameFlow.selectedGeometry].Place(EGameFlow.selectedGeometry,
                        new Vector3((int)mainCamera.raycast.point.x + 0.5f, (int)mainCamera.raycast.point.y, (mainCamera.raycast.point.z)),
                        new Vector3(0, yRotation, 0), Vector3.one, true);
                }
                else if (mainCamera.raycast.normal == Vector3.left)
                {
                    yRotation = 90;
                    Geometry.Dictionary[EGameFlow.selectedGeometry].Place(EGameFlow.selectedGeometry,
                        new Vector3(mainCamera.raycast.point.x, (int)mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z) + 0.5f),
                        new Vector3(0, yRotation, 0), Vector3.one, true);
                }
                else if (mainCamera.raycast.normal == Vector3.forward)
                {
                    yRotation = 180;
                    Geometry.Dictionary[EGameFlow.selectedGeometry].Place(EGameFlow.selectedGeometry,
                        new Vector3((int)mainCamera.raycast.point.x + 0.5f, (int)mainCamera.raycast.point.y, (mainCamera.raycast.point.z)),
                        new Vector3(0, yRotation, 0), Vector3.one, true);
                }
                else if (mainCamera.raycast.normal == Vector3.right)
                {
                    yRotation = 270;
                    Geometry.Dictionary[EGameFlow.selectedGeometry].Place(EGameFlow.selectedGeometry,
                        new Vector3(mainCamera.raycast.point.x, (int)mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z) + 0.5f),
                        new Vector3(0, yRotation, 0), Vector3.one, true);
                }
            }
        }
    }


    public static void Cancel()
    {

    }


    public static void Detect(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
        {
            // Check if we are aiming at the top face of a voxel
            if (mainCamera.raycast.normal.y >= 0.75f)
            {
                // Detects the voxel
                DevConstructionToolsManager.chunk = world.chunk[(int)((mainCamera.raycast.point.x) / world.chunkSize.x),
                                                           (int)((mainCamera.raycast.point.y + 0.5f) / world.chunkSize.y),
                                                           (int)((mainCamera.raycast.point.z) / world.chunkSize.z)];

                DevConstructionToolsManager.voxel = DevConstructionToolsManager.chunk.voxel[(int)((mainCamera.raycast.point.x) % world.chunkSize.x),
                                                                                (int)((mainCamera.raycast.point.y + 0.5f) % world.chunkSize.y),
                                                                                (int)((mainCamera.raycast.point.z) % world.chunkSize.z)];
            }
        }
    }
}
