using UnityEngine;
using System.Collections;

public class SDFireBallBehaviour : MonoBehaviour 
{
    private Vector3 direction;
    private bool isColliding;

    private float damage;
    private float blastRadius;

    private int initialxplosionCounter = 100;
    private int explosionCounter;

    // Explosion
    private Light light;
    private float maxLightIntensity = 4;
    private float maxLightRange = 15;

    public void Init(Vector3 direction, float damage, float blastRadius)
    {
        this.damage = damage;
        this.blastRadius = blastRadius;
        this.direction = direction;
        isColliding = false;

        // Explosion relative
        transform.FindChild("Explosion").active = false;
        explosionCounter = initialxplosionCounter;
    }


	void Update () 
    {
        if (!isColliding)
        {
            if (!EGameFlow.pause)
            {
                // The position of the fireBall without the y component
                transform.position += direction * Time.deltaTime;
                direction.y -= EGamePhysics.gravity * Time.deltaTime;

                // Destroy depending on distance to the player
                if (transform.position.y < -10)
                    Destroy(gameObject);
            }
        }
        // After impact
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
                transform.FindChild("Explosion").active = true;
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


    void OnCollisionEnter(Collision other)
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
            else if (other.gameObject.tag == "Chunk")
            {
                Debug.Log(transform.position);
            }
        }
    }
}
