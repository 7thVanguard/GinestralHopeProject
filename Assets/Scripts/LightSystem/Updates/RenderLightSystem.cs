using UnityEngine;
using System.Collections;

public class RenderLightSystem
{
    private float r, g, b;


    public void Sunrise()
    {
        r = (SLightSystem.ambientSunRise.r + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.ambientMidDay.r - SLightSystem.ambientSunRise.r));
        g = (SLightSystem.ambientSunRise.g + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.ambientMidDay.g - SLightSystem.ambientSunRise.g));
        b = (SLightSystem.ambientSunRise.b + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.ambientMidDay.b - SLightSystem.ambientSunRise.b));

        SetGameObject();
    }


    public void MidDay()
    {
        r = (SLightSystem.ambientMidDay.r + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.ambientMidDay.r - SLightSystem.ambientNoon.r));
        g = (SLightSystem.ambientMidDay.g + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.ambientMidDay.g - SLightSystem.ambientNoon.g));
        b = (SLightSystem.ambientMidDay.b + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.ambientMidDay.b - SLightSystem.ambientNoon.b));

        SetGameObject();
    }


    public void Noon()
    {
        if (SLightSystem.dayTime <= 120)     // 30 degree adapt ambient light blends in 30 degrees
        {
            r = (SLightSystem.ambientNoon.r + ((SLightSystem.dayTime - 90) / 30) * -(SLightSystem.ambientNoon.r - SLightSystem.ambientNight.r));
            g = (SLightSystem.ambientNoon.g + ((SLightSystem.dayTime - 90) / 30) * -(SLightSystem.ambientNoon.g - SLightSystem.ambientNight.g));
            b = (SLightSystem.ambientNoon.b + ((SLightSystem.dayTime - 90) / 30) * -(SLightSystem.ambientNoon.b - SLightSystem.ambientNight.b));
        }
        else
        {
            r = SLightSystem.ambientNight.r;
            g = SLightSystem.ambientNight.g;
            b = SLightSystem.ambientNight.b;
        }

        SetGameObject();
    }


    public void Night()
    {
        if (SLightSystem.dayTime >= 240)    // 30 degree adapt ambient light blends in 30 degrees
        {
            r = (SLightSystem.ambientNight.r + ((SLightSystem.dayTime - 240) / 30) * SLightSystem.ambientSunRise.r);
            g = (SLightSystem.ambientNight.g + ((SLightSystem.dayTime - 240) / 30) * SLightSystem.ambientSunRise.g);
            b = (SLightSystem.ambientNight.b + ((SLightSystem.dayTime - 240) / 30) * SLightSystem.ambientSunRise.b);
        }
        else
        {
            r = SLightSystem.ambientNight.r;
            g = SLightSystem.ambientNight.g;
            b = SLightSystem.ambientNight.b;
        }

        SetGameObject();
    }


    private void SetGameObject()
    {
        RenderSettings.ambientLight = new Color(r, g, b);
    }
}
