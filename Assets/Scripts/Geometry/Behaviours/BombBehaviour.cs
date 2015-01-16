using UnityEngine;
using System.Collections;

public class BombBehaviour : MonoBehaviour 
{
    World world;

    private GameObject runes;
    private GameObject glow;

    private int damage;
    private int blastRadius;
    private float downCounter;
    private bool launch = false;

    // Color
    Color glowColor;
    Color baseBombColor;
    Color bombColor;

    private float initialFadeCounter = 0.5f;
    private float partialFadeCounter;
    private float fadeCounter;
    private bool fadeOut = true;

    // Explosion
    private float toExplosionTime = 7;
    private float initialxplosionCounter = 2;

    private Light light;
    private float maxLightIntensity = 5;
    private float maxLightRange = 26;

    private bool exploded = false;
    private bool finished = false;


	public void Init(World world)
    {
        this.world = world;

        transform.FindChild("Explosion").gameObject.SetActive(false);
        transform.FindChild("Smoke").gameObject.SetActive(false);
        light = transform.FindChild("Explosion").light;
        
        damage = 8;
        blastRadius = 16;

        glowColor = transform.FindChild("AnimatedRunes").FindChild("RunesGlow").gameObject.renderer.material.GetColor("_TintColor");
        baseBombColor = transform.FindChild("Bomb").renderer.material.color;
        bombColor = transform.FindChild("Bomb").renderer.material.color;

        fadeCounter = initialFadeCounter;
        partialFadeCounter = initialFadeCounter;
        downCounter = toExplosionTime;

        launch = true;
    }


	void Update () 
    {
        if (!GameFlow.pause && launch)
        {
            if (!exploded)
            {
                downCounter -= Time.deltaTime;

                // Rotates the runes
                transform.FindChild("AnimatedRunes").eulerAngles += new Vector3(0, 150 * Time.deltaTime, 0);

                // Vertices color (Glow and Bomb)
                if (fadeOut)
                {
                    fadeCounter -= Time.deltaTime;
                    if (fadeCounter <= 0)
                        fadeOut = false;
                }
                else
                {
                    fadeCounter += Time.deltaTime;
                    if (fadeCounter >= partialFadeCounter)
                        fadeOut = true;
                }

                // varies the fadeIn and fadeOut speed
                if (downCounter < toExplosionTime / 2.0f)
                    if (fadeCounter < partialFadeCounter / 2.0f)
                        partialFadeCounter = initialFadeCounter / 2.0f;

                if (downCounter < toExplosionTime / 4.0f)
                    if (fadeCounter < partialFadeCounter / 2.0f)
                        partialFadeCounter = initialFadeCounter / 4.0f;

                // Set the colors
                glowColor.a = fadeCounter;
                bombColor.r = baseBombColor.r + (1 - baseBombColor.r) * ((partialFadeCounter - fadeCounter) / partialFadeCounter);
                bombColor.g = (fadeCounter / partialFadeCounter) * baseBombColor.g;
                bombColor.b = (fadeCounter / partialFadeCounter) * baseBombColor.b;

                // Assign the color
                glowColor.a = fadeCounter * (1.0f / initialFadeCounter);
                transform.FindChild("AnimatedRunes").FindChild("RunesGlow").renderer.material.SetColor("_TintColor", glowColor);
                transform.FindChild("Bomb").renderer.material.color = bombColor;

                // Explosion
                if (downCounter <= 0)
                {
                    exploded = true;
                    downCounter = initialxplosionCounter;
                }
            }
            else if (!finished)
            {
                // Deactivate on impact
                if (downCounter == initialxplosionCounter)
                {
                    // Explosion relative
                    Transform.Destroy(transform.GetComponent<SphereCollider>());
                    Destroy(transform.FindChild("AnimatedRunes").gameObject);
                    Destroy(transform.FindChild("Bomb").gameObject);
                    transform.FindChild("Explosion").gameObject.SetActive(true);
                    transform.FindChild("Explosion").gameObject.particleSystem.playbackSpeed = 0.75f;
                    transform.FindChild("Smoke").gameObject.SetActive(true);
                    transform.FindChild("Smoke").gameObject.particleSystem.playbackSpeed = 0.35f;
                    light = transform.FindChild("Explosion").light;

                    // Destroy near objects
                    VoxelLib.Explosion(world, transform.position, damage, blastRadius);
                }

                // Explosion relative
                downCounter -= Time.deltaTime;
                light.intensity = maxLightIntensity * downCounter / initialxplosionCounter;
                light.range = maxLightRange * downCounter / initialxplosionCounter;

                // Destroy the bomb
                if (downCounter <= 0)
                {
                    downCounter = 7;
                    finished = true;
                }
            }
            else
            {
                // Smoke
                downCounter -= Time.deltaTime;
                
                if (downCounter <= 0)
                    Destroy(this.gameObject);
            }
        }
	}
}
