using UnityEngine;
using System.Collections;

public class EnemiesToolManager
{
    private static GameObject gameObject;

    public static void Select(MainCamera mainCamera)
    {
        if (mainCamera.raycast.transform.gameObject.tag == "Enemy")
        {
            if (gameObject != null)
            {
                gameObject.GetComponent<EnemyComponent>().isSelected = false;
                gameObject.renderer.material.color = Color.white;
            }

            gameObject = mainCamera.raycast.transform.gameObject;
            gameObject.GetComponent<EnemyComponent>().isSelected = true;

            gameObject.renderer.material.color = Color.red;
        }
        else
        {
            if (gameObject != null)
            {
                gameObject.GetComponent<EnemyComponent>().isSelected = false;
                gameObject.renderer.material.color = Color.white;
            }
        }
    }
	
	
	public static void Place(World world, Player player, MainCamera mainCamera)
	{
        if (mainCamera.raycast.distance < (player.constructionDetection + mainCamera.maxDistance) && mainCamera.raycast.distance != 0)
            if (mainCamera.raycast.normal.y >= 0.75f)
                Enemy.Dictionary[EGameFlow.selectedEnemy].Place(new Vector3((int)(mainCamera.raycast.point.x), mainCamera.raycast.point.y, (int)(mainCamera.raycast.point.z)));
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
