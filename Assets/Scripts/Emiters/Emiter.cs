using UnityEngine;
using System.Collections;

public class Emiter 
{
	public static void Place(Vector3 position, int intensityAndRange, byte r, byte g, byte b)
	{
		GameObject emiterObj = new GameObject();
		emiterObj.name = "Light Emiter";
		emiterObj.tag = "Emiter";
		emiterObj.transform.position = position;
		emiterObj.light.intensity = intensityAndRange / 100;
		emiterObj.light.range = intensityAndRange % 100;

		emiterObj.light.color = new Color (r, g, b);
	}
}
