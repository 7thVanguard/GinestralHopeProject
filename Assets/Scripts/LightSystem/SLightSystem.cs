using UnityEngine;
using System.Collections;

public class SLightSystem
{
    // Light transform
    public static Transform transform;

    // DayNight cycle duration relative
    public static float dayDuration = 1200;
    public static float dayTime;
    public static float beginingTime = 270;

    // Season relative
    public static float maxSunAngle = 45;
    public static float maxIntensity = 0.9f;
    public static float minIntensity = 0;

    // Sun colors
    public static Color sunSunRise = new Color(218 / 255.0f, 105 / 255.0f, 39 / 255.0f);
    public static Color sunMidDay = new Color (255 / 255.0f, 255 / 255.0f, 255 / 255.0f);
    public static Color sunNoon = new Color (218 / 255.0f, 87 / 255.0f, 39 / 255.0f);

    // Flare colors
    public static Color flareSunRise = new Color(220 / 255.0f, 150 / 255.0f, 90 / 255.0f);
    public static Color flareMidDay = new Color(231 / 255.0f, 217 / 255.0f, 17 / 255.0f);
    public static Color flareNoon = new Color(189 / 255.0f, 82 / 255.0f, 16 / 255.0f);

    // Ambient light colors
    public static Color ambientSunRise = new Color(49 / 255.0f, 43 / 255.0f, 37 / 255.0f);
    public static Color ambientMidDay = new Color(82 / 255.0f, 84 / 255.0f, 78 / 255.0f);
    public static Color ambientNoon = new Color(84 / 255.0f, 70 / 255.0f, 57 / 255.0f);
    public static Color ambientNight = new Color(5 / 255.0f, 5 / 255.0f, 5 / 255.0f);

    // Ambient light colors
    public static Color backGroundSunRise = new Color(71 / 255.0f, 40 / 255.0f, 29 / 255.0f);
    public static Color backGroundMidDay = new Color(115 / 255.0f, 150 / 255.0f, 180 / 255.0f);
    public static Color backGroundNoon = new Color(52 / 255.0f, 54 / 255.0f, 44 / 255.0f);
    public static Color backGroundNight = new Color(2 / 255.0f, 2 / 255.0f, 2 / 255.0f);
}
