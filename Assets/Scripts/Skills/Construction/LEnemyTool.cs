using UnityEngine;
using System.Collections;

public class LEnemyTool
{
	public static void Remove()
	{

	}
	
	
	public static void Place(World world, Player player)
	{
		if (EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
            if (CameraRaycast.impact.distance < (player.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0) 
				if (CameraRaycast.impact.normal.y >= 0.75f)
				{
					switch (EGameFlow.selectedEnemy) 
					{
						case EGameFlow.SelectedEnemy.NORMALSLIME:
                            LEnemy.placeNormalSlime(world, new Vector3((int)(CameraRaycast.impact.point.x), CameraRaycast.impact.point.y + 0.5f, (int)(CameraRaycast.impact.point.z)));
							break;
						default:
							break;
					}
				}
	}
	
	
	public static void Cancel()
	{
		
	}
	
	
	public static void Detect(World world, Player player)
	{
        if (CameraRaycast.impact.distance < (player.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0)
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
