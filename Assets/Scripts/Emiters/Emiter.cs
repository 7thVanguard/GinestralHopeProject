using UnityEngine;
using System.Collections;

public class Emiter 
{
    public static void Place(Vector3 position, float intensity, float range, float r, float g, float b)
	{
		GameObject emiterObj = new GameObject();
		emiterObj.name = "Light Emiter";
		emiterObj.tag = "Emiter";

		emiterObj.AddComponent<Light>();
		emiterObj.light.type = LightType.Point;
		emiterObj.transform.position = position;

		emiterObj.light.intensity = intensity;
		emiterObj.light.range = range;

		emiterObj.light.color = new Color (r, g, b);
	}
}
