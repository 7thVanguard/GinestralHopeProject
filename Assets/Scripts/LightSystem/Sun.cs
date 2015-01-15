using UnityEngine;
using System.Collections;

public class Sun
{
    public LightSystemBehaviour lightSystemBehaviour;
    public GameObject sunObj;
    public Light light;
    public LensFlare lensFlare;

    public Color lightColor;
    public Color flareColor;

    public float dayTime;
    public float sunAngle;

    public float intensity;
    public float ambientLight;


    public Sun(Player player)
    {
        lightSystemBehaviour = new LightSystemBehaviour();

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
    }


    public void Update()
    {
        Quaternion rotation = Quaternion.Euler(sunAngle, dayTime, 0);
        sunObj.transform.position = rotation * (new Vector3(0, 0, -100));
        sunObj.transform.rotation = rotation;


    }
}
