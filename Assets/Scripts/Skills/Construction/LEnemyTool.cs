using UnityEngine;
using System.Collections;

public class LEnemyTool
{
	public static void Remove()
	{

	}
	
	
	public static void Place(World world, Player player, MainCamera mainCAmera)
	{
		if (EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
            if (mainCAmera.raycast.distance < (player.constructionDetection + SCamera.distance) && mainCAmera.raycast.distance != 0)
                if (mainCAmera.raycast.normal.y >= 0.75f)
				{
					switch (EGameFlow.selectedEnemy) 
					{
						case EGameFlow.SelectedEnemy.NORMALSLIME:
                            LEnemy.placeNormalSlime(world, new Vector3((int)(mainCAmera.raycast.point.x), mainCAmera.raycast.point.y + 0.5f, (int)(mainCAmera.raycast.point.z)));
							break;
						default:
							break;
					}
				}
	}
	
	
	public static void Cancel()
	{
		
	}
	
	
	public static void Detect(World world, Player player, MainCamera mainCamera)
	{
        if (mainCamera.raycast.distance < (player.constructionDetection + SCamera.distance) && mainCamera.raycast.distance != 0)
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
