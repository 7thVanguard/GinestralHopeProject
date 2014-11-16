using UnityEngine;
using System.Collections;

public class SunLightSystem : LightSystemBehaviour
{
    // Sun colors
    private Color sunSunRise = new Color(218 / 255.0f, 105 / 255.0f, 39 / 255.0f);
    private Color sunMidDay = new Color(255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
    private Color sunNoon = new Color(218 / 255.0f, 87 / 255.0f, 39 / 255.0f);

    private float sunAngle;
    private float intensity;
    private float r, g, b;


    public GameObject Sunrise(Player player, GameObject gameObject, float dayTime)
    {
        r = (sunSunRise.r + ((dayTime - 270) / 90) * (sunMidDay.r - sunSunRise.r));
        g = (sunSunRise.g + ((dayTime - 270) / 90) * (sunMidDay.g - sunSunRise.g));
        b = (sunSunRise.b + ((dayTime - 270) / 90) * (sunMidDay.b - sunSunRise.b));

        intensity = (dayTime - 252) / 90;
        sunAngle = (dayTime - 270) / (90 / maxSunAngle);

        SetGameObject(player, gameObject, dayTime);

        return gameObject;
	}


    public GameObject MidDay(Player player, GameObject gameObject, float dayTime)
    {
        r = (sunMidDay.r + ((dayTime - 0) / 90) * -(sunMidDay.r - sunNoon.r));
        g = (sunMidDay.g + ((dayTime - 0) / 90) * -(sunMidDay.g - sunNoon.g));
        b = (sunMidDay.b + ((dayTime - 0) / 90) * -(sunMidDay.b - sunNoon.b));

        intensity = (90 - (dayTime - 18)) / 90;
        sunAngle = (90 - dayTime) / (90 / maxSunAngle);

        SetGameObject(player, gameObject, dayTime);

        return gameObject;
    }


    public GameObject Noon(Player player, GameObject gameObject, float dayTime)
    {
        r = (sunNoon.r + ((dayTime - 90) / 90) * -sunNoon.r);
        g = (sunNoon.g + ((dayTime - 90) / 90) * -sunNoon.g);
        b = (sunNoon.b + ((dayTime - 90) / 90) * -sunNoon.b);

        sunAngle = (90 - dayTime) / (90 / maxSunAngle);
        intensity = (90 - (dayTime - 18)) / 90;

        SetGameObject(player, gameObject, dayTime);

        return gameObject;
    }


    public GameObject Night(Player player, GameObject gameObject, float dayTime)
    {
        r = (0 + ((dayTime - 180) / 90) * sunSunRise.r);
        g = (0 + ((dayTime - 180) / 90) * sunSunRise.g);
        b = (0 + ((dayTime - 180) / 90) * sunSunRise.b);

        sunAngle = (dayTime - 270) / (90 / maxSunAngle);
        intensity = (dayTime - 252) / 90;

        SetGameObject(player, gameObject, dayTime);

        return gameObject;
    }


    private GameObject SetGameObject(Player player, GameObject gameObject, float dayTime)
    {
        Mathf.Clamp(intensity, minIntensity, maxIntensity);

        Quaternion rotation = Quaternion.Euler(sunAngle, dayTime, 0);
        gameObject.transform.position = rotation * (new Vector3(0, 0, -100)) + player.playerObj.transform.position;
        gameObject.transform.rotation = rotation;

        gameObject.light.color = new Color(r, g, b);

        // Intensity clamp
        if (intensity < minIntensity)
            intensity = minIntensity;
        else if (intensity > maxIntensity)
            intensity = maxIntensity;

        gameObject.light.intensity = intensity;

        return gameObject;
    }
}
