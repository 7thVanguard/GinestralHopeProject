using UnityEngine;
using System.Collections;

public class LightSystemBehaviour 
{
    private Player player;

    private SunLightSystem sunLightSystem;
    private FlareLightSystem flareLightSystem;
    private RenderLightSystem renderLightSystem;
    private CameraLightSystem cameraLightSystem;

    protected GameObject sun;
    protected LensFlare lensFlare;

    // DayNight cycle duration relative
    protected const float dayDuration = 1200;
    protected const float beginingTime = 270;

    // Season relative
    protected const float maxSunAngle = 45;
    protected const float maxIntensity = 0.9f;
    protected const float minIntensity = 0;

    // Changing variables
    private float gameTime;
    private float dayTime;


    public void Init(Player player, GameObject sun, LensFlare lensFlare)
    {
        this.player = player;
        this.sun = sun;
        this.lensFlare = lensFlare;

        sunLightSystem = new SunLightSystem();
        flareLightSystem = new FlareLightSystem();
        renderLightSystem = new RenderLightSystem();
        cameraLightSystem = new CameraLightSystem();

        gameTime = 95;
    }
	


	public void Update ()
    {
        // Developer auxiliar
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (sun.light.shadows == LightShadows.None)
                sun.light.shadows = LightShadows.Hard;
            else
                sun.light.shadows = LightShadows.None;
        }

        if (!EGameFlow.pause)
        {
            // Time passing calculation
            gameTime += Time.deltaTime;
            dayTime = ((gameTime % dayDuration) / dayDuration) * 360;
            dayTime = (dayTime + beginingTime) % 360;


            if (dayTime < 90)
            {
                sunLightSystem.MidDay(player, sun, dayTime);
                flareLightSystem.MidDay(lensFlare, dayTime);
                renderLightSystem.MidDay(dayTime);
                cameraLightSystem.MidDay(dayTime);
            }
            else if (dayTime < 180)
            {
                sunLightSystem.Noon(player, sun, dayTime);
                flareLightSystem.Noon(lensFlare, dayTime);
                renderLightSystem.Noon(dayTime);
                cameraLightSystem.Noon(dayTime);
            }
            else if (dayTime < 270)
            {
                sunLightSystem.Night(player, sun, dayTime);
                flareLightSystem.Night(lensFlare, dayTime);
                renderLightSystem.Night(dayTime);
                cameraLightSystem.Night(dayTime);
            }
            else
            {
                sunLightSystem.Sunrise(player, sun, dayTime);
                flareLightSystem.Sunrise(lensFlare, dayTime);
                renderLightSystem.Sunrise(dayTime);
                cameraLightSystem.Sunrise(dayTime);
            }
        }
	}
}
