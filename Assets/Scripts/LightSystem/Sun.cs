using UnityEngine;
using System.Collections;

public class Sun
{
    public GameObject sunObj;
    public Light light;
    public LensFlare lensFlare;


    public Sun(Player player)
    {
        Init();
    }


    private void Init()
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
        light = sunObj.GetComponent<Light>();
        sunObj.AddComponent<LensFlare>();
        lensFlare = sunObj.GetComponent<LensFlare>();
        lensFlare.flare = (Flare)Resources.Load("LightFlares/50mm Zoom");

        light.type = LightType.Directional;
        light.shadows = LightShadows.Hard;

        sunObj.AddComponent<LightSystemBehaviour>();
        sunObj.GetComponent<LightSystemBehaviour>().Init(Global.player, this, lensFlare);
    }
}
