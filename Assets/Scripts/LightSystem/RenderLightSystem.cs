using UnityEngine;
using System.Collections;

public class RenderLightSystem : LightSystemBehaviour
{
    // Ambient light colors
    private Color ambientSunRise = new Color(49 / 255.0f, 43 / 255.0f, 37 / 255.0f);
    private Color ambientMidDay = new Color(82 / 255.0f, 84 / 255.0f, 78 / 255.0f);
    private Color ambientNoon = new Color(84 / 255.0f, 70 / 255.0f, 57 / 255.0f);
    private Color ambientNight = new Color(5 / 255.0f, 5 / 255.0f, 5 / 255.0f);

    private float r, g, b;


    public void Sunrise(float dayTime)
    {
        r = (ambientSunRise.r + ((dayTime - 270) / 90) * (ambientMidDay.r - ambientSunRise.r));
        g = (ambientSunRise.g + ((dayTime - 270) / 90) * (ambientMidDay.g - ambientSunRise.g));
        b = (ambientSunRise.b + ((dayTime - 270) / 90) * (ambientMidDay.b - ambientSunRise.b));

        SetGameObject();
    }


    public void MidDay(float dayTime)
    {
        r = (ambientMidDay.r + ((dayTime - 0) / 90) * -(ambientMidDay.r - ambientNoon.r));
        g = (ambientMidDay.g + ((dayTime - 0) / 90) * -(ambientMidDay.g - ambientNoon.g));
        b = (ambientMidDay.b + ((dayTime - 0) / 90) * -(ambientMidDay.b - ambientNoon.b));

        SetGameObject();
    }


    public void Noon(float dayTime)
    {
        if (dayTime <= 120)     // 30 degree adapt ambient light blends in 30 degrees
        {
            r = (ambientNoon.r + ((dayTime - 90) / 30) * -(ambientNoon.r - ambientNight.r));
            g = (ambientNoon.g + ((dayTime - 90) / 30) * -(ambientNoon.g - ambientNight.g));
            b = (ambientNoon.b + ((dayTime - 90) / 30) * -(ambientNoon.b - ambientNight.b));
        }
        else
        {
            r = ambientNight.r;
            g = ambientNight.g;
            b = ambientNight.b;
        }

        SetGameObject();
    }


    public void Night(float dayTime)
    {
        if (dayTime >= 240)    // 30 degree adapt ambient light blends in 30 degrees
        {
            r = (ambientNight.r + ((dayTime - 240) / 30) * ambientSunRise.r);
            g = (ambientNight.g + ((dayTime - 240) / 30) * ambientSunRise.g);
            b = (ambientNight.b + ((dayTime - 240) / 30) * ambientSunRise.b);
        }
        else
        {
            r = ambientNight.r;
            g = ambientNight.g;
            b = ambientNight.b;
        }

        SetGameObject();
    }


    private void SetGameObject()
    {
        RenderSettings.ambientLight = new Color(r, g, b);
    }
}
