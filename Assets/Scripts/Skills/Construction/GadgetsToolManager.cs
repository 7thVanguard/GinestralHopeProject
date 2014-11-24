using UnityEngine;
using System.Collections;

public class GadgetsToolManager
{
    public static void Remove(Player player, MainCamera mainCamera)
    {
        // Picks back the gadget
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
            if (mainCamera.raycast.transform.gameObject.tag == "Gadget")
            {
                Gadget gadget = Gadget.Dictionary[mainCamera.raycast.transform.gameObject.name];

                // returns the gadged if it's not a component giver, else gives it's components
                if (gadget.givesComponents)
                    GameComponentDictionary.GameComponentsDictionary[gadget.ID].count += gadget.dropCount;
                else
                    gadget.count += gadget.dropCount;

                Object.Destroy(mainCamera.raycast.transform.gameObject);
            }
    }


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
        {
            if (mainCamera.raycast.normal.y >= 0.75f && Gadget.Dictionary[EGameFlow.selectedGadget].placedOnFloor)
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

                Gadget.Dictionary[EGameFlow.selectedGadget].Place(EGameFlow.selectedGadget, 
                    new Vector3((int)(mainCamera.raycast.point.x) + 0.5f, mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z) + 0.5f), new Vector3(0, yRotation, 0));
            }
            else if (mainCamera.raycast.normal.y == 0 && !Gadget.Dictionary[EGameFlow.selectedGadget].placedOnFloor)
            {
                int yRotation;

                if (mainCamera.raycast.normal == Vector3.back)
                {
                    yRotation = 0;
                    Gadget.Dictionary[EGameFlow.selectedGadget].Place(EGameFlow.selectedGadget,
                        new Vector3((int)mainCamera.raycast.point.x + 0.5f, (int)mainCamera.raycast.point.y, (mainCamera.raycast.point.z)),
                        new Vector3(0, yRotation, 0));
                }
                else if (mainCamera.raycast.normal == Vector3.left)
                {
                    yRotation = 90;
                    Gadget.Dictionary[EGameFlow.selectedGadget].Place(EGameFlow.selectedGadget,
                        new Vector3(mainCamera.raycast.point.x, (int)mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z + 0.5f)),
                        new Vector3(0, yRotation, 0));
                }
                else if (mainCamera.raycast.normal == Vector3.forward)
                {
                    yRotation = 180;
                    Gadget.Dictionary[EGameFlow.selectedGadget].Place(EGameFlow.selectedGadget,
                        new Vector3((int)mainCamera.raycast.point.x + 0.5f, (int)mainCamera.raycast.point.y, (mainCamera.raycast.point.z)),
                        new Vector3(0, yRotation, 0));
                }
                else if (mainCamera.raycast.normal == Vector3.right)
                {
                    yRotation = 270;
                    Gadget.Dictionary[EGameFlow.selectedGadget].Place(EGameFlow.selectedGadget,
                        new Vector3(mainCamera.raycast.point.x, (int)mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z + 0.5f)),
                        new Vector3(0, yRotation, 0));
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
                DevConstructionSkillsManager.chunk = world.chunk[(int)((mainCamera.raycast.point.x) / world.chunkSize.x),
                                                           (int)((mainCamera.raycast.point.y + 0.5f) / world.chunkSize.y),
                                                           (int)((mainCamera.raycast.point.z) / world.chunkSize.z)];

                DevConstructionSkillsManager.voxel = DevConstructionSkillsManager.chunk.voxel[(int)((mainCamera.raycast.point.x) % world.chunkSize.x),
                                                                                (int)((mainCamera.raycast.point.y + 0.5f) % world.chunkSize.y),
                                                                                (int)((mainCamera.raycast.point.z) % world.chunkSize.z)];
            }
        }
    }
}