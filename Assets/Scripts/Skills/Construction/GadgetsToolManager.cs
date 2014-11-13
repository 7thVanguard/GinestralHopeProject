using UnityEngine;
using System.Collections;

public class GadgetsToolManager
{
    public static void Remove(Player player, MainCamera mainCamera)
    {
        // Picks back the gadget
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.distance) && mainCamera.raycast.distance != 0)
            if (mainCamera.raycast.transform.gameObject.tag == "Gadget")
            {
                Gadget gadget = GadgetDictionary.GadgetsDictionary[mainCamera.raycast.transform.gameObject.name];

                // returns the gadged if it's not a component giver, else gives it's components
                if (gadget.givesComponents)
                    GameComponentDictionary.GameComponentsDictionary[gadget.nameKey].count += gadget.dropCount;
                else
                    gadget.count += gadget.dropCount;

                Object.Destroy(mainCamera.raycast.transform.gameObject);
            }
    }


    public static void Place(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.distance) && mainCamera.raycast.distance != 0)
        {
            if (mainCamera.raycast.normal.y >= 0.75f)
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

                switch (EGameFlow.selectedGadget)
                {
                    case "Wooden Plank":
                        LVGadget.placePlank(new Vector3((int)(mainCamera.raycast.point.x), mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z)), yRotation);
                        break;
                    case "Wood Pieces":
                        LVGadget.placeWoodPiecesGadget(world, new Vector3((int)(mainCamera.raycast.point.x), mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z)));
                        break;
                    case "Nails":
                        LVGadget.placeNailsGadget(world, new Vector3((int)(mainCamera.raycast.point.x), mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z)));
                        break;
                    case "Wooden Ladder":
                        break;
                    default:
                        break;
                }
            }
        }
    }


    public static void Cancel()
    {

    }


    public static void Detect(World world, Player player, MainCamera mainCamera)
    {
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.distance) && mainCamera.raycast.distance != 0)
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