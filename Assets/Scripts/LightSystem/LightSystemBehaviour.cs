using UnityEngine;
using System.Collections;

public class LightSystemBehaviour : MonoBehaviour
{
    private Player player;
    private Sun sun;
    protected LensFlare lensFlare;

    public Color lightColor;
    public Color flareColor;

    public Color ambientLightColor;

    public Color backGroundColor;

    public float intensity;

    public bool update = false;
    public bool setActual = false;


    public void Init(Player player, Sun sun, LensFlare lensFlare)
    {
        this.player = player;
        this.sun = sun;
        this.lensFlare = lensFlare;
    }



    void Update()
    {
        // Developer auxiliar
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (sun.light.shadows == LightShadows.None)
                sun.light.shadows = LightShadows.Hard;
            else
                sun.light.shadows = LightShadows.None;
        }

        if (update)
        {
            sun.light.color = lightColor;
            sun.light.intensity = intensity;

            sun.lensFlare.color = flareColor;

            RenderSettings.ambientLight = ambientLightColor;

            Camera.main.backgroundColor = backGroundColor;

            update = false;
        }

        if (setActual)
        {
            lightColor = sun.light.color;
            intensity = sun.light.intensity;

            flareColor = sun.lensFlare.color;

            ambientLightColor = RenderSettings.ambientLight;
            backGroundColor = Camera.main.backgroundColor;

            setActual = false;
        }
    }
}