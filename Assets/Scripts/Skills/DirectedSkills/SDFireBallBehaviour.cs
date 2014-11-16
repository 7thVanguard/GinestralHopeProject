using UnityEngine;
using System.Collections;

public class SDFireBallBehaviour : MonoBehaviour 
{
    private Vector3 direction;
    private bool isColliding;


    public void Init(Vector3 direction)
    {
        this.direction = direction;
        isColliding = false;
    }


	void Update () 
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
                other.gameObject.GetComponent<EnemyComponent>().Damage(1);
            else if (other.gameObject.tag == "Player")
                other.gameObject.GetComponent<PlayerComponent>().Damage(1);

            Destroy(gameObject);
        }
    }
}
