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
                InventoryDictionary.GlobalVoxelInventory[CameraRaycast.impact.transform.gameObject.name].count++;
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