using UnityEngine;
using System.Collections;

public class Emiter 
{
    public static void Place(World world, Vector3 position, float intensity, float range, float r, float g, float b)
	{
		GameObject emiterObj = new GameObject();
        SphereCollider collider = emiterObj.AddComponent<SphereCollider>();
		emiterObj.name = "Light Emiter";
		emiterObj.tag = "Emiter";

		emiterObj.AddComponent<Light>();
		emiterObj.light.type = LightType.Point;
		emiterObj.transform.position = position;
        emiterObj.transform.parent = world.emitersController.transform;

		emiterObj.light.intensity = intensity;
		emiterObj.light.range = range;

		emiterObj.light.color = new Color (r, g, b);

        collider.radius = 0.25f;
	}
}
