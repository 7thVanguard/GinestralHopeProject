using UnityEngine;
using System.Collections;

public class CameraLightSystem
{
    private float r, g, b;


    public void Sunrise()
    {
        r = (SLightSystem.backGroundSunRise.r + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.backGroundMidDay.r - SLightSystem.backGroundSunRise.r));
        g = (SLightSystem.backGroundSunRise.g + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.backGroundMidDay.g - SLightSystem.backGroundSunRise.g));
        b = (SLightSystem.backGroundSunRise.b + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.backGroundMidDay.b - SLightSystem.backGroundSunRise.b));

        SetGameObject();
    }


    public void MidDay()
    {
        r = (SLightSystem.backGroundMidDay.r + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.backGroundMidDay.r - SLightSystem.backGroundNoon.r));
        g = (SLightSystem.backGroundMidDay.g + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.backGroundMidDay.g - SLightSystem.backGroundNoon.g));
        b = (SLightSystem.backGroundMidDay.b + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.backGroundMidDay.b - SLightSystem.backGroundNoon.b));

        SetGameObject();
    }


    public void Noon()
    {
        if (SLightSystem.dayTime <= 120)     // 30 degree adapt backGround light blends in 30 degrees
        {
            r = (SLightSystem.backGroundNoon.r + ((SLightSystem.dayTime - 90) / 30) * -(SLightSystem.backGroundNoon.r - SLightSystem.backGroundNight.r));
            g = (SLightSystem.backGroundNoon.g + ((SLightSystem.dayTime - 90) / 30) * -(SLightSystem.backGroundNoon.g - SLightSystem.backGroundNight.g));
            b = (SLightSystem.backGroundNoon.b + ((SLightSystem.dayTime - 90) / 30) * -(SLightSystem.backGroundNoon.b - SLightSystem.backGroundNight.b));
        }
        else
        {
            r = SLightSystem.backGroundNight.r;
            g = SLightSystem.backGroundNight.g;
            b = SLightSystem.backGroundNight.b;
        }

        SetGameObject();
    }


    public void Night()
    {
        if (SLightSystem.dayTime >= 240)    // 30 degree adapt backGround light blends in 30 degrees
        {
            r = (SLightSystem.backGroundNight.r + ((SLightSystem.dayTime - 240) / 30) * SLightSystem.backGroundSunRise.r);
            g = (SLightSystem.backGroundNight.g + ((SLightSystem.dayTime - 240) / 30) * SLightSystem.backGroundSunRise.g);
            b = (SLightSystem.backGroundNight.b + ((SLightSystem.dayTime - 240) / 30) * SLightSystem.backGroundSunRise.b);
        }
        else
        {
            r = SLightSystem.backGroundNight.r;
            g = SLightSystem.backGroundNight.g;
            b = SLightSystem.backGroundNight.b;
        }

        SetGameObject();
    }


    private void SetGameObject()
    {
        Camera.main.backgroundColor = new Color(r, g, b);
    }
}
