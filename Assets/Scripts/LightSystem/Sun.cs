using UnityEngine;
using System.Collections;

public class Sun
{
    public Sun(Player player, Flare sunFlare)
    {
        Init(player, sunFlare);
    }


    private void Init(Player player, Flare sunFlare)
    {
        // Sun
        GameObject sun = new GameObject();

        sun.name = "Sun";

        // Set sun transforms
        sun.transform.position = Vector3.zero;
        sun.transform.eulerAngles = new Vector3(50, 30, 0);
        sun.transform.localScale = Vector3.one;


        // Light components creation
        sun.AddComponent<Light>();
        sun.AddComponent<LensFlare>();
        sun.AddComponent<ULightSystem>();
        sun.GetComponent<ULightSystem>().Init(player);

        sun.light.type = LightType.Directional;
        sun.light.shadows = LightShadows.Hard;

        sun.GetComponent<LensFlare>().flare = sunFlare;
    }
}
