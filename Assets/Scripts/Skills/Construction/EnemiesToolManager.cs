using UnityEngine;
using System.Collections;

public class EnemiesToolManager
{
	public static void Remove()
	{

	}
	
	
	public static void Place(World world, Player player, MainCamera mainCamera)
	{
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.distance) && mainCamera.raycast.distance != 0)
            if (mainCamera.raycast.normal.y >= 0.75f)
            {
                Debug.Log(EGameFlow.selectedEnemy);
                Enemy.Dictionary[EGameFlow.selectedEnemy].Place(new Vector3((int)(mainCamera.raycast.point.x), mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z)));
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
