using UnityEngine;
using System.Collections;

public class LEnemyTool
{
	public static void Remove()
	{

	}
	
	
	public static void Place()
	{
		if (EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
			if (CameraRaycast.impact.distance < (SPlayer.constructionDetection + SCamera.distance) && CameraRaycast.impact.distance != 0) 
				if (CameraRaycast.impact.normal.y >= 0.75f)
				{
					switch (EGameFlow.selectedEnemy) 
					{
						case EGameFlow.SelectedEnemy.NORMALSLIME:
                            LEnemy.placeNormalSlime(new Vector3((int)(CameraRaycast.impact.point.x), CameraRaycast.impact.point.y + 0.5f, (int)(CameraRaycast.impact.point.z)));
							break;
						default:
							break;
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
            if (CameraRaycast.impact.normal.y >= 0.75f)
            {
                // Detects the voxel
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
