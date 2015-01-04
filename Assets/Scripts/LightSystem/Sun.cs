using UnityEngine;
using System.Collections;

public class Sun
{
    public LightSystemBehaviour lightSystemBehaviour;
    public GameObject sunObj;
    public LensFlare lensFlare;


    public Sun(Player player)
    {
        lightSystemBehaviour = new LightSystemBehaviour();

        Init(player);
    }


    private void Init(Player player)
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
        lensFlare.flare = (Flare)Resources.Load("LightFlares/50mm Zoom");
        
        sunObj.light.type = LightType.Directional;
        sunObj.light.shadows = LightShadows.Hard;
    }
}
