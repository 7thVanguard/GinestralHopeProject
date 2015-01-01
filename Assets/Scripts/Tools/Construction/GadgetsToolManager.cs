using UnityEngine;
using System.Collections;

public class GadgetsToolManager
{
    public static void Remove(Player player, MainCamera mainCamera)
    {
        Object.Destroy(mainCamera.raycast.transform.gameObject);
    }


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.distance) && mainCamera.raycast.distance != 0)
        {
            if (mainCamera.raycast.normal.y >= 0.75f && Interactive.Dictionary[GameFlow.selectedInteractive].placedOn == Interactive.PlacedOn.FLOOR)
            {
                // Claculates the initial position and the rotation of the Gadget we are going to place
                int yRotation;

                if (Camera.main.transform.eulerAngles.y < 45 || Camera.main.transform.eulerAngles.y > 315)
                    yRotation = 0;
                else if (Camera.main.transform.eulerAngles.y < 135)
                    yRotation = 90;
                else if (Camera.main.transform.eulerAngles.y < 225)
                    yRotation = 180;
                else
                    yRotation = 270;

                Interactive.Dictionary[GameFlow.selectedInteractive].Place(GameFlow.selectedInteractive, 
                    new Vector3((int)(mainCamera.raycast.point.x) + 0.5f, mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z) + 0.5f), 
                    new Vector3(0, yRotation, 0), true);
            }
            else if (mainCamera.raycast.normal.y == 0 && Interactive.Dictionary[GameFlow.selectedInteractive].placedOn == Interactive.PlacedOn.WALL)
            {
                int yRotation;

                if (mainCamera.raycast.normal == Vector3.back)
                {
                    yRotation = 0;
                    Interactive.Dictionary[GameFlow.selectedInteractive].Place(GameFlow.selectedInteractive,
                        new Vector3((int)mainCamera.raycast.point.x + 0.5f, (int)mainCamera.raycast.point.y, (mainCamera.raycast.point.z)),
                        new Vector3(0, yRotation, 0), true);
                }
                else if (mainCamera.raycast.normal == Vector3.left)
                {
                    yRotation = 90;
                    Interactive.Dictionary[GameFlow.selectedInteractive].Place(GameFlow.selectedInteractive,
                        new Vector3(mainCamera.raycast.point.x, (int)mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z) + 0.5f),
                        new Vector3(0, yRotation, 0), true);
                }
                else if (mainCamera.raycast.normal == Vector3.forward)
                {
                    yRotation = 180;
                    Interactive.Dictionary[GameFlow.selectedInteractive].Place(GameFlow.selectedInteractive,
                        new Vector3((int)mainCamera.raycast.point.x + 0.5f, (int)mainCamera.raycast.point.y, (mainCamera.raycast.point.z)),
                        new Vector3(0, yRotation, 0), true);
                }
                else if (mainCamera.raycast.normal == Vector3.right)
                {
                    yRotation = 270;
                    Interactive.Dictionary[GameFlow.selectedInteractive].Place(GameFlow.selectedInteractive,
                        new Vector3(mainCamera.raycast.point.x, (int)mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z) + 0.5f),
                        new Vector3(0, yRotation, 0), true);
                }
            }
        }
    }


    public static void Cancel()
    {

    }


    public static void Detect(World world, Player player, MainCamera mainCamera)
    {

    }
}