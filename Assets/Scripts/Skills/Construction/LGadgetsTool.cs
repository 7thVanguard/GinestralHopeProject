using UnityEngine;
using System.Collections;

public class LGadgetsTool
{
    public static void Remove()
    {
        // Picks back the gadget
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
            if (CameraRaycast.impact.transform.gameObject.tag == "Gadget")
            {
                Gadget gadget = GadgetDictionary.GadgetsDictionary[CameraRaycast.impact.transform.gameObject.name];

                // returns the gadged if it's not a component giver, else gives it's components
                if (gadget.givesComponents)
                    GameComponentDictionary.GameComponentsDictionary[gadget.nameKey].count += gadget.dropCount;
                else
                    gadget.count += gadget.dropCount;

                Object.Destroy(CameraRaycast.impact.transform.gameObject);
            }
    }


    public static void Place(World world)
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            if (CameraRaycast.impact.normal.y >= 0.75f)
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
                    case EGameFlow.SelectedGadget.PLANK:
                        LVGadget.placePlank(new Vector3((int)(CameraRaycast.impact.point.x), CameraRaycast.impact.point.y, (int)(CameraRaycast.impact.point.z)), yRotation);
                        break;
                    case EGameFlow.SelectedGadget.WOOD:
                        LVGadget.placeWoodPiecesGadget(world, new Vector3((int)(CameraRaycast.impact.point.x), CameraRaycast.impact.point.y, (int)(CameraRaycast.impact.point.z)));
                        break;
                    case EGameFlow.SelectedGadget.NAILS:
                        LVGadget.placeNailsGadget(world, new Vector3((int)(CameraRaycast.impact.point.x), CameraRaycast.impact.point.y, (int)(CameraRaycast.impact.point.z)));
                        break;
                    case EGameFlow.SelectedGadget.LADDER:
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


    public static void Detect(World world)
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            // Check if we are aiming at the top face of a voxel
            if (CameraRaycast.impact.normal.y >= 0.75f)
            {
                // Detects the voxel
                DevConstructionSkills.chunk = world.chunk[(int)((CameraRaycast.impact.point.x) / world.chunkSize.x),
                                                           (int)((CameraRaycast.impact.point.y + 0.5f) / world.chunkSize.y),
                                                           (int)((CameraRaycast.impact.point.z) / world.chunkSize.z)];

                DevConstructionSkills.voxel = DevConstructionSkills.chunk.voxel[(int)((CameraRaycast.impact.point.x) % world.chunkSize.x),
                                                                                (int)((CameraRaycast.impact.point.y + 0.5f) % world.chunkSize.y),
                                                                                (int)((CameraRaycast.impact.point.z) % world.chunkSize.z)];
            }
        }
    }
}