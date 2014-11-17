using UnityEngine;
using System.Collections;

public class SkillDirected : Skill
{
    protected Vector3 originPosition;
    protected Vector3 targetPosition;
    protected Vector3 objectDirection;
    protected Vector3 direction;


    public override void Init(World world, Player player, MainCamera mainCamera, Skill skill)
    {
        
    }


    public override void CastDirected(GameObject gameObject, Vector3 origin, bool launchedByPlayer)
    {
        // Set tag
        gameObject.tag = "Skill";

        // Set transforms
        gameObject.transform.position = player.playerObj.transform.position;

        // Ignoring the raycasts
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        // Add components
        gameObject.AddComponent<Rigidbody>();

        //+ Player target selection
        if (launchedByPlayer)
        {
            // Target location
            if (PlayerCombat.target == null)
            {
                if (mainCamera.raycast.distance < maxDistance && mainCamera.raycast.distance != 0)
                    targetPosition = mainCamera.raycast.point;
                else
                    targetPosition = Camera.main.transform.position + Camera.main.transform.forward * maxDistance;
            }
            else
                targetPosition = PlayerCombat.target.transform.position;
        }
        //+ Enemy target selection
        else
        {
            targetPosition = player.playerObj.transform.position;
        }

        //+ Fire
        // Detecting initial direction
        objectDirection = targetPosition - origin;
        objectDirection.Normalize();
        objectDirection *= objectSpeed;

        // We fire in front of the caster instead of inside him
        originPosition = origin + objectDirection.normalized * 4 / 5;
    }


    public override void FireDirected(GameObject gameObject, Vector3 originPosition, Vector3 targetPosition, Vector3 objectDirection, int objectSpeed)
    {
        float flyTime;

        // Setting flight variables
        flyTime = Vector3.Distance(originPosition, targetPosition) / objectSpeed;

        // Initial direction
        direction.x = objectDirection.x;
        direction.y = (targetPosition.y - originPosition.y + 0.5f * EGamePhysics.gravity * Mathf.Pow(flyTime, 2)) / flyTime;
        direction.z = objectDirection.z;

        gameObject.transform.position = originPosition;
    }
}
