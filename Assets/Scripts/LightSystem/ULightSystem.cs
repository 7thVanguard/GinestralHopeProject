using UnityEngine;
using System.Collections;

public class ULightSystem : MonoBehaviour 
{
    Player player;

    SunLightSystem sunLightSystem;
    FlareLightSystem flareLightSystem;
    RenderLightSystem renderLightSystem;
    CameraLightSystem cameraLightSystem;

    LensFlare lensFlare;
    float gameTime = 95;


    public void Init(Player player)
    {
        this.player = player;
    }


	void Awake ()
    {
        sunLightSystem = new SunLightSystem();
        flareLightSystem = new FlareLightSystem();
        renderLightSystem = new RenderLightSystem();
        cameraLightSystem = new CameraLightSystem();

        lensFlare = GetComponent<LensFlare>();

        gameObject.light.color = SLightSystem.sunSunRise;
        lensFlare.color = SLightSystem.flareSunRise;
        RenderSettings.ambientLight = SLightSystem.ambientSunRise;
        Camera.main.backgroundColor = SLightSystem.backGroundSunRise;
	}
	


	void Update ()
    {
        // Developer auxiliar
        if (Input.GetKeyUp(KeyCode.L))
        {
            if (gameObject.light.shadows == LightShadows.None)
                gameObject.light.shadows = LightShadows.Hard;
            else
                gameObject.light.shadows = LightShadows.None;
        }

        if (!EGameFlow.pause)
        {
            // Time passing calculation
            gameTime += Time.deltaTime;
            SLightSystem.dayTime = ((gameTime % SLightSystem.dayDuration) / SLightSystem.dayDuration) * 360;
            SLightSystem.dayTime = (SLightSystem.dayTime + SLightSystem.beginingTime) % 360;


            if (SLightSystem.dayTime < 90)
            {
                sunLightSystem.MidDay(player, gameObject);
                flareLightSystem.MidDay(lensFlare);
                renderLightSystem.MidDay();
                cameraLightSystem.MidDay();
            }
            else if (SLightSystem.dayTime < 180)
            {
                sunLightSystem.Noon(player, gameObject);
                flareLightSystem.Noon(lensFlare);
                renderLightSystem.Noon();
                cameraLightSystem.Noon();
            }
            else if (SLightSystem.dayTime < 270)
            {
                sunLightSystem.Night(player, gameObject);
                flareLightSystem.Night(lensFlare);
                renderLightSystem.Night();
                cameraLightSystem.Night();
            }
            else
            {
                sunLightSystem.Sunrise(player, gameObject);
                flareLightSystem.Sunrise(lensFlare);
                renderLightSystem.Sunrise();
                cameraLightSystem.Sunrise();
            }

            SLightSystem.transform = transform;
        }
	}
}
