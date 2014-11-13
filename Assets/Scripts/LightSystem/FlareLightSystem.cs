using UnityEngine;
using System.Collections;

public class FlareLightSystem : LightSystemBehaviour
{
    // Flare colors
    private Color flareSunRise = new Color(220 / 255.0f, 150 / 255.0f, 90 / 255.0f);
    private Color flareMidDay = new Color(231 / 255.0f, 217 / 255.0f, 17 / 255.0f);
    private Color flareNoon = new Color(189 / 255.0f, 82 / 255.0f, 16 / 255.0f);

    private float r, g, b;


    public LensFlare Sunrise(LensFlare lensFlare, float dayTime)
    {
        r = (flareSunRise.r + ((dayTime - 270) / 90) * (flareMidDay.r - flareSunRise.r));
        g = (flareSunRise.g + ((dayTime - 270) / 90) * (flareMidDay.g - flareSunRise.g));
        b = (flareSunRise.b + ((dayTime - 270) / 90) * (flareMidDay.b - flareSunRise.b));

        SetGameObject(lensFlare);

        return lensFlare;
    }


    public LensFlare MidDay(LensFlare lensFlare, float dayTime)
    {
        r = (flareMidDay.r + ((dayTime - 0) / 90) * -(flareMidDay.r - flareNoon.r));
        g = (flareMidDay.g + ((dayTime - 0) / 90) * -(flareMidDay.g - flareNoon.g));
        b = (flareMidDay.b + ((dayTime - 0) / 90) * -(flareMidDay.b - flareNoon.b));


        SetGameObject(lensFlare);

        return lensFlare;
    }


    public LensFlare Noon(LensFlare lensFlare, float dayTime)
    {
        r = (flareNoon.r + ((dayTime - 90) / 90) * -flareNoon.r);
        g = (flareNoon.g + ((dayTime - 90) / 90) * -flareNoon.g);
        b = (flareNoon.b + ((dayTime - 90) / 90) * -flareNoon.b);

        SetGameObject(lensFlare);

        return lensFlare;
    }


    public LensFlare Night(LensFlare lensFlare, float dayTime)
    {
        r = (0 + ((dayTime - 180) / 90) * flareSunRise.r);
        g = (0 + ((dayTime - 180) / 90) * flareSunRise.g);
        b = (0 + ((dayTime - 180) / 90) * flareSunRise.b);

        SetGameObject(lensFlare);

        return lensFlare;
    }


    private LensFlare SetGameObject(LensFlare lensFlare)
    {
        lensFlare.color = new Color(r, g, b);
        return lensFlare;
    }
}
