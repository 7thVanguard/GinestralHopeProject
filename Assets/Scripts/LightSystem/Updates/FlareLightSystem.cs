using UnityEngine;
using System.Collections;

public class FlareLightSystem
{
    private float r, g, b;


    public LensFlare Sunrise(LensFlare lensFlare)
    {
        r = (SLightSystem.flareSunRise.r + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.flareMidDay.r - SLightSystem.flareSunRise.r));
        g = (SLightSystem.flareSunRise.g + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.flareMidDay.g - SLightSystem.flareSunRise.g));
        b = (SLightSystem.flareSunRise.b + ((SLightSystem.dayTime - 270) / 90) * (SLightSystem.flareMidDay.b - SLightSystem.flareSunRise.b));

        SetGameObject(lensFlare);

        return lensFlare;
    }


    public LensFlare MidDay(LensFlare lensFlare)
    {
        r = (SLightSystem.flareMidDay.r + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.flareMidDay.r - SLightSystem.flareNoon.r));
        g = (SLightSystem.flareMidDay.g + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.flareMidDay.g - SLightSystem.flareNoon.g));
        b = (SLightSystem.flareMidDay.b + ((SLightSystem.dayTime - 0) / 90) * -(SLightSystem.flareMidDay.b - SLightSystem.flareNoon.b));


        SetGameObject(lensFlare);

        return lensFlare;
    }


    public LensFlare Noon(LensFlare lensFlare)
    {
        r = (SLightSystem.flareNoon.r + ((SLightSystem.dayTime - 90) / 90) * -SLightSystem.flareNoon.r);
        g = (SLightSystem.flareNoon.g + ((SLightSystem.dayTime - 90) / 90) * -SLightSystem.flareNoon.g);
        b = (SLightSystem.flareNoon.b + ((SLightSystem.dayTime - 90) / 90) * -SLightSystem.flareNoon.b);

        SetGameObject(lensFlare);

        return lensFlare;
    }


    public LensFlare Night(LensFlare lensFlare)
    {
        r = (0 + ((SLightSystem.dayTime - 180) / 90) * SLightSystem.flareSunRise.r);
        g = (0 + ((SLightSystem.dayTime - 180) / 90) * SLightSystem.flareSunRise.g);
        b = (0 + ((SLightSystem.dayTime - 180) / 90) * SLightSystem.flareSunRise.b);

        SetGameObject(lensFlare);

        return lensFlare;
    }


    private LensFlare SetGameObject(LensFlare lensFlare)
    {
        lensFlare.color = new Color(r, g, b);
        return lensFlare;
    }
}
