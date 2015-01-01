using UnityEngine;
using System.Collections;

public class SDFireMineBehaviour : MonoBehaviour 
{
    public enum SDFireMineState { ALLOCATION, LATENT, FIRE }
    private SDFireMineState sdFireMineState = SDFireMineState.ALLOCATION;

    RaycastHit impact;

    // Trajectory
    private Vector3 direction;
    private bool isColliding;

    // Fire
    private float damage;
    private float blastRadius;

    // Explosion
    private int initialxplosionCounter = 100;
    private int explosionCounter;

    private Light light;
    private float maxLightIntensity = 4;
    private float maxLightRange = 15;

    // Trail
    private bool updateActivation = false;

    // Latent variables
    private float maxLatencyTime = 10;

    // Launch variables
    private int launchMaxSpeed = 50;


    public void Init(Player player, Vector3 direction, float damage, float blastRadius)
    {
        this.damage = damage;
        this.blastRadius = blastRadius;
        this.direction = direction;
        isColliding = false;

        // Player Ignore
        Collider playerCollider = player.playerObj.GetComponent<Collider>();
        Physics.IgnoreCollision(playerCollider, collider);

        // Explosion relative
        transform.FindChild("Explosion").gameObject.SetActive(false);
        transform.FindChild("Trail").gameObject.SetActive(false);
        explosionCounter = initialxplosionCounter;
    }


    void Update()
    {
        if (!GameFlow.pause)
        {
            switch (sdFireMineState)
            {
                case SDFireMineState.ALLOCATION:
                    {
                        transform.position += direction * Time.deltaTime;
                        maxLatencyTime -= Time.deltaTime;

                        if (maxLatencyTime <= 0)
                        {
                            sdFireMineState = SDFireMineState.FIRE;
                            isColliding = true;
                        }
                    }
                    break;
                case SDFireMineState.LATENT:
                    {
                        maxLatencyTime -= Time.deltaTime;

                        if (maxLatencyTime <= 0)
                        {
                            sdFireMineState = SDFireMineState.FIRE;
                            isColliding = true;
                        }
                    }
                    break;
                case SDFireMineState.FIRE:
                    {
                        if (!isColliding)
                        {
                            //+ Impact detection by raycast
                            if (Physics.Raycast(transform.position, direction, out impact, 1f))
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
                                    else if (impact.transform.gameObject.tag == "Chunk")
                                    {
                                        Debug.Log(transform.position);
                                    }
                                }
                            }

                            //+ Normal movement
                            // if the raycast don't detect a collision 
                            if (!isColliding)
                            {
                                // movement Update
                                transform.position += direction * Time.deltaTime;
                                direction += direction.normalized / 2;
                                maxLatencyTime -= Time.deltaTime;

                                // Activate the trail in the second frame, avoiding a trail glitch
                                if (!updateActivation)
                                {
                                    updateActivation = true;
                                    transform.FindChild("Trail").gameObject.SetActive(true);
                                }

                                // Destroy depending on the ball position
                                if (maxLatencyTime <= 0)
                                    isColliding = true;
                            }
                        }

                        //+ Explosion
                        else
                        {
                            // Deactivate on impact
                            if (explosionCounter == initialxplosionCounter)
                            {
                                Destroy(transform.FindChild("Ball").gameObject);
                                Destroy(transform.FindChild("Glow").gameObject);
                                Destroy(transform.FindChild("Light").gameObject);
                                Destroy(transform.FindChild("Trail").gameObject);

                                // Explosion relative
                                transform.FindChild("Explosion").gameObject.SetActive(true);
                                light = transform.FindChild("Explosion").light;
                            }

                            // Explosion relative
                            explosionCounter--;
                            light.intensity = maxLightIntensity * explosionCounter / initialxplosionCounter;
                            light.range = maxLightRange * explosionCounter / initialxplosionCounter;


                            if (explosionCounter <= 0)
                                Destroy(gameObject);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }


    //+ Impact detection by rigid body (Allocation and Fire phases)
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag != "Skill")
        {
            switch (sdFireMineState)
            {
                case SDFireMineState.ALLOCATION:
                    {
                        if (other.gameObject.tag != "Player")
                        {
                            sdFireMineState = SDFireMineState.LATENT;
                            gameObject.GetComponent<SphereCollider>().isTrigger = true;
                            gameObject.GetComponent<SphereCollider>().radius = 20;
                            maxLatencyTime = 10;
                        }
                    }
                    break;
                case SDFireMineState.FIRE:
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
                        else if (other.gameObject.tag == "Chunk")
                        {
                            Debug.Log(transform.position);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }


    //+ Impact detection by trigger (Latent phase)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            sdFireMineState = SDFireMineState.FIRE;
            Transform.Destroy(gameObject.GetComponent<SphereCollider>());
            direction = (other.transform.position - transform.position).normalized;
            maxLatencyTime = 10;
        }
    }
}
