using UnityEngine;
using System.Collections;

public class SDFrostBoltBehaviour : MonoBehaviour 
{
    World world;
    RaycastHit impact;

    // Trajectory
    private Vector3 direction;
    private bool isColliding;
    private bool launchedByPlayer;

    // Fire
    private float damage;
    private int blastRadius;

    // Explosion
    private float initialxplosionCounter = 1.66f;
    private float explosionCounter;

    private Light light;
    private float maxLightIntensity = 4;
    private float maxLightRange = 15;

    // Trail
    private bool updateActivation = false;


    private float timeCounter = 20;



    public void Init(World world, Vector3 direction, float damage, int blastRadius)
    {
        this.world = world;
        this.damage = damage;
        this.blastRadius = blastRadius;
        this.direction = direction;
        isColliding = false;

        // Explosion relative
        transform.FindChild("Explosion").gameObject.SetActive(false);
        transform.FindChild("Trail").gameObject.SetActive(false);
        explosionCounter = initialxplosionCounter;
    }


    void Update()
    {
        if (!GameFlow.pause)
        {
            if (!isColliding)
            {
                //+ Impact detection by raycast
                if (Physics.Raycast(transform.position, direction, out impact, 0.5f))
                {
                    if (impact.transform.gameObject.tag != "Skill")
                    {
                        // test if already collided (bug solver)
                        if (isColliding)
                            return;
                        isColliding = true;

                        // Impact result
                        if (impact.transform.gameObject.tag == "Enemy")
                            impact.transform.gameObject.GetComponent<EnemyComponent>().Damage(damage);
                        else if (impact.transform.gameObject.tag == "Player")
                            impact.transform.gameObject.GetComponent<PlayerComponent>().Damage(damage);
                    }
                }

                //+ Normal movement
                // if the raycast don't detect a collision
                if (!isColliding)
                {
                    // The position of the frostBall without the y component
                    transform.position += direction * Time.deltaTime;

                    // Activate the trail in the second frame, avoiding a trail glitch
                    if (!updateActivation)
                    {
                        updateActivation = true;
                        transform.FindChild("Trail").gameObject.SetActive(true);
                    }

                    // Destroy depending on the elapsed time
                    timeCounter -= Time.deltaTime;
                    if (timeCounter <= 0)
                        Destroy(this.gameObject);
                }
            }

            //+ Explosion
            else
            {
                // Deactivate on impact
                if (explosionCounter == initialxplosionCounter)
                {
                    Destroy(transform.FindChild("Ball").gameObject);
                    Destroy(transform.FindChild("Light").gameObject);
                    Destroy(transform.FindChild("Trail").gameObject);

                    // Explosion relative
                    transform.FindChild("Explosion").gameObject.SetActive(true);
                    light = transform.FindChild("Explosion").light;
                }

                // Explosion relative
                explosionCounter -= Time.deltaTime;
                light.intensity = maxLightIntensity * explosionCounter / initialxplosionCounter;
                light.range = maxLightRange * explosionCounter / initialxplosionCounter;


                if (explosionCounter <= 0)
                    Destroy(gameObject);
            }
        }
    }


    //+ Impact detection by rigid body
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag != "Skill")
        {
            // test if already collided (bug solver)
            if (isColliding)
                return;
            isColliding = true;

            // Impact result
            if (other.gameObject.tag == "Enemy")
                other.gameObject.GetComponent<EnemyComponent>().Damage(damage);
            else if (other.gameObject.tag == "Player")
                other.gameObject.GetComponent<PlayerComponent>().Damage(damage);
        }
    }
}
