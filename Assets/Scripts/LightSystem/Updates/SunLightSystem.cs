using UnityEngine;
using System.Collections;

public class SunLightSystem
{
    private float sunAngle;
    private float intensity;
    private float r, g, b;


    public GameObject Sunrise(Player player, GameObject gameObject)
    {
        r = (SLightSystem.sunSunRise.r + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.sunMidDay.r - SLightSystem.sunSunRise.r));
        g = (SLightSystem.sunSunRise.g + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.sunMidDay.g - SLightSystem.sunSunRise.g));
        b = (SLightSystem.sunSunRise.b + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.sunMidDay.b - SLightSystem.sunSunRise.b));

        intensity = (SLightSystem.dayTime - 252) / 90;
        sunAngle = (SLightSystem.dayTime - 270) / (90 / SLightSystem.maxSunAngle);

        SetGameObject(player, gameObject);

        return gameObject;
	}


    public GameObject MidDay(Player player, GameObject gameObject)
    {
        r = (SLightSystem.sunMidDay.r + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.sunMidDay.r - SLightSystem.sunNoon.r));
        g = (SLightSystem.sunMidDay.g + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.sunMidDay.g - SLightSystem.sunNoon.g));
        b = (SLightSystem.sunMidDay.b + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.sunMidDay.b - SLightSystem.sunNoon.b));

        intensity = (90 - (SLightSystem.dayTime - 18)) / 90;
        sunAngle = (90 - SLightSystem.dayTime) / (90 / SLightSystem.maxSunAngle);

        SetGameObject(player, gameObject);

        return gameObject;
    }


    public GameObject Noon(Player player, GameObject gameObject)
    {
        r = (SLightSystem.sunNoon.r + ((SLightSystem.dayTime - 90) / 90) * -SLightSystem.sunNoon.r);
        g = (SLightSystem.sunNoon.g + ((SLightSystem.dayTime - 90) / 90) * -SLightSystem.sunNoon.g);
        b = (SLightSystem.sunNoon.b + ((SLightSystem.dayTime - 90) / 90) * -SLightSystem.sunNoon.b);

        sunAngle = (90 - SLightSystem.dayTime) / (90 / SLightSystem.maxSunAngle);
        intensity = (90 - (SLightSystem.dayTime - 18)) / 90;

        SetGameObject(player, gameObject);

        return gameObject;
    }


    public GameObject Night(Player player, GameObject gameObject)
    {
        r = (0 + ((SLightSystem.dayTime - 180) / 90) * SLightSystem.sunSunRise.r);
        g = (0 + ((SLightSystem.dayTime - 180) / 90) * SLightSystem.sunSunRise.g);
        b = (0 + ((SLightSystem.dayTime - 180) / 90) * SLightSystem.sunSunRise.b);

        sunAngle = (SLightSystem.dayTime - 270) / (90 / SLightSystem.maxSunAngle);
        intensity = (SLightSystem.dayTime - 252) / 90;

        SetGameObject(player, gameObject);

        return gameObject;
    }


    private GameObject SetGameObject(Player player, GameObject gameObject)
    {
        Mathf.Clamp(intensity, SLightSystem.minIntensity, SLightSystem.maxIntensity);

        Quaternion rotation = Quaternion.Euler(sunAngle, SLightSystem.dayTime, 0);
        gameObject.transform.position = rotation * (new Vector3(0, 0, -100)) + player.playerObj.transform.position;
        gameObject.transform.rotation = rotation;

        gameObject.light.color = new Color(r, g, b);

        // Intensity clamp
        if (intensity < SLightSystem.minIntensity)
            intensity = SLightSystem.minIntensity;
        else if (intensity > SLightSystem.maxIntensity)
            intensity = SLightSystem.maxIntensity;

        gameObject.light.intensity = intensity;

        return gameObject;
    }
}
