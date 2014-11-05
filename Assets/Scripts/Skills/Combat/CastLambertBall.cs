using UnityEngine;
using System.Collections;

public class CastLambertBall : MonoBehaviour
{
    private Vector3 direction;
    private bool isColliding;


    public void Initialize(Vector3 target, Vector3 initialDirection, float ballSpeed)
    {
        Vector3 origin;
        float flyTime;

        // Setting flight variables
        origin = SPlayer.transform.position + initialDirection.normalized * 2;
        flyTime = Vector3.Distance(origin, target) / ballSpeed;

        // Initial direction
        direction.x = initialDirection.x;
        direction.y = (target.y - origin.y + 0.5f * EGamePhysics.gravity * Mathf.Pow(flyTime, 2)) / flyTime;
        direction.z = initialDirection.z;

        transform.position = origin;

        isColliding = false;
    }


    void Update()
    {
        if (!EGameFlow.pause)
        {
            // The position of the fireBall without the y component
            transform.position += direction * Time.deltaTime;
            direction.y -= EGamePhysics.gravity * Time.deltaTime;

            // Destroy depending on distance to the player
            if (Vector3.Distance(transform.position, SPlayer.transform.position) > 200)
                Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision other)
    {
        // testc if already collided
        if (isColliding)
            return;
        isColliding = true;

        if (other.gameObject.tag == "Enemy")
            other.gameObject.GetComponent<EnemyComponent>().Damage(1);
        else if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<UPlayer>().combat.Damage(1);

        Destroy(gameObject);
    }
}
