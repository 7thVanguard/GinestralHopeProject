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
                Debug.Log(CameraRaycast.impact.transform.gameObject.name);
                Gadget gadget = GadgetDictionary.GadgetsDictionary[CameraRaycast.impact.transform.gameObject.name];

                // returns the gadged if it's not a component giver, else gives it's components
                if (gadget.givesComponents)
                {
                    GameComponentDictionary.GameComponentsDictionary[gadget.nameKey].count += gadget.dropCount;
                }
                else
                    gadget.count += gadget.dropCount;

                Object.Destroy(CameraRaycast.impact.transform.gameObject);
            }
    }


    public static void Place()
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
                        LVGadget.placeWoodPiecesGadget(new Vector3((int)(CameraRaycast.impact.point.x), CameraRaycast.impact.point.y, (int)(CameraRaycast.impact.point.z)));
                        break;
                    case EGameFlow.SelectedGadget.NAILS:
                        LVGadget.placeNailsGadget(new Vector3((int)(CameraRaycast.impact.point.x), CameraRaycast.impact.point.y, (int)(CameraRaycast.impact.point.z)));
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


    public static void Detect()
    {
        if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
        {
            // Check if we are aiming at the top face of a voxel
            if (CameraRaycast.impact.normal == Vector3.up)
            {
                // Detects the vertex we are aiming at
                DevConstructionSkills.chunk = SWorld.chunk[(int)((CameraRaycast.impact.point.x) / SWorld.chunkSize.x),
                                                           (int)((CameraRaycast.impact.point.y + 0.5f) / SWorld.chunkSize.y),
                                                           (int)((CameraRaycast.impact.point.z) / SWorld.chunkSize.z)];

                DevConstructionSkills.voxel = DevConstructionSkills.chunk.voxel[(int)((CameraRaycast.impact.point.x) % SWorld.chunkSize.x),
                                                                                (int)((CameraRaycast.impact.point.y + 0.5f) % SWorld.chunkSize.y),
                                                                                (int)((CameraRaycast.impact.point.z) % SWorld.chunkSize.z)];
            }
        }
    }
}