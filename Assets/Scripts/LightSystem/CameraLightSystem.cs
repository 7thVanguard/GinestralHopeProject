using UnityEngine;
using System.Collections;

public class CameraLightSystem : LightSystemBehaviour
{
    // Ambient light colors
    private Color backGroundSunRise = new Color(71 / 255.0f, 40 / 255.0f, 29 / 255.0f);
    private Color backGroundMidDay = new Color(115 / 255.0f, 150 / 255.0f, 180 / 255.0f);
    private Color backGroundNoon = new Color(52 / 255.0f, 54 / 255.0f, 44 / 255.0f);
    private Color backGroundNight = new Color(2 / 255.0f, 2 / 255.0f, 2 / 255.0f);

    private float r, g, b;


    public void Sunrise(float dayTime)
    {
        r = (backGroundSunRise.r + ((dayTime - 270) / 90) * (backGroundMidDay.r - backGroundSunRise.r));
        g = (backGroundSunRise.g + ((dayTime - 270) / 90) * (backGroundMidDay.g - backGroundSunRise.g));
        b = (backGroundSunRise.b + ((dayTime - 270) / 90) * (backGroundMidDay.b - backGroundSunRise.b));

        SetGameObject();
    }


    public void MidDay(float dayTime)
    {
        r = (backGroundMidDay.r + ((dayTime - 0) / 90) * -(backGroundMidDay.r - backGroundNoon.r));
        g = (backGroundMidDay.g + ((dayTime - 0) / 90) * -(backGroundMidDay.g - backGroundNoon.g));
        b = (backGroundMidDay.b + ((dayTime - 0) / 90) * -(backGroundMidDay.b - backGroundNoon.b));

        SetGameObject();
    }


    public void Noon(float dayTime)
    {
        if (dayTime <= 120)     // 30 degree adapt backGround light blends in 30 degrees
        {
            r = (backGroundNoon.r + ((dayTime - 90) / 30) * -(backGroundNoon.r - backGroundNight.r));
            g = (backGroundNoon.g + ((dayTime - 90) / 30) * -(backGroundNoon.g - backGroundNight.g));
            b = (backGroundNoon.b + ((dayTime - 90) / 30) * -(backGroundNoon.b - backGroundNight.b));
        }
        else
        {
            r = backGroundNight.r;
            g = backGroundNight.g;
            b = backGroundNight.b;
        }

        SetGameObject();
    }


    public void Night(float dayTime)
    {
        if (dayTime >= 240)    // 30 degree adapt backGround light blends in 30 degrees
        {
            r = (backGroundNight.r + ((dayTime - 240) / 30) * backGroundSunRise.r);
            g = (backGroundNight.g + ((dayTime - 240) / 30) * backGroundSunRise.g);
            b = (backGroundNight.b + ((dayTime - 240) / 30) * backGroundSunRise.b);
        }
        else
        {
            r = backGroundNight.r;
            g = backGroundNight.g;
            b = backGroundNight.b;
        }

        SetGameObject();
    }


    private void SetGameObject()
    {
        Camera.main.backgroundColor = new Color(r, g, b);
    }
}
