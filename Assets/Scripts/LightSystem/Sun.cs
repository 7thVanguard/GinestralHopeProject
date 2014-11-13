using UnityEngine;
using System.Collections;

public class Sun
{
    public LightSystemBehaviour lightSystemBehaviour;
    public GameObject sunObj;
    public LensFlare lensFlare;


    public Sun(Player player, Flare sunFlare)
    {
        lightSystemBehaviour = new LightSystemBehaviour();

        Init(player, sunFlare);
    }


    private void Init(Player player, Flare sunFlare)
    {
        // Sun
        sunObj = new GameObject();

        sunObj.name = "Sun";

        // Set sun transforms
        sunObj.transform.position = Vector3.zero;
        sunObj.transform.eulerAngles = new Vector3(50, 30, 0);
        sunObj.transform.localScale = Vector3.one;


        // Light components creation
        sunObj.AddComponent<Light>();
        sunObj.AddComponent<LensFlare>();
        lensFlare = sunObj.GetComponent<LensFlare>();
        lensFlare.flare = sunFlare;
        
        sunObj.light.type = LightType.Directional;
        sunObj.light.shadows = LightShadows.Hard;
    }
}
