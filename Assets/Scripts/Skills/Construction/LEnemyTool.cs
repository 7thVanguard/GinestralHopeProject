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

	}
}
