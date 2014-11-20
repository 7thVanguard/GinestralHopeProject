using UnityEngine;
using System.Collections;

public class SDFireMine : SkillDirected 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Skill skill)
    {
        base.world = world;
        base.player = player;
        base.mainCamera = mainCamera;

        // Global
        ID = "Fire Mine";

        // Flight
        skillTrajectory = Skill.SkillTrajectory.LINEAR;
        objectSpeed = 10;
        maxDistance = 50;

        // CAst
        castingTime = 5;

        // Fire
        damage = 6;
        blastRadius = 5;
    }


    public override void CastDirected(GameObject mineBall, Vector3 origin, bool launchedByPlayer)
    {
        // Create the object
        Transform mineBallTransform = Object.Instantiate(world.skills.FindChild("Fireball2")) as Transform;
        mineBall = mineBallTransform.gameObject;
        mineBall.name = "Fire Mine";

        // Call base function
        base.CastDirected(mineBall, origin, launchedByPlayer);

        // Call next function
        FireDirected(mineBall, base.originPosition, base.targetPosition, base.objectDirection, objectSpeed);
    }


    public override void FireDirected(GameObject mineBall, Vector3 originPosition, Vector3 targetPosition, Vector3 ballDirection, int ballSpeed)
    {
        // Set transforms
        mineBall.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Set components
        mineBall.AddComponent<SDFireMineBehaviour>();
        mineBall.GetComponent<Rigidbody>().useGravity = false;
        mineBall.AddComponent<SphereCollider>();
        mineBall.GetComponent<SphereCollider>().radius = 0.5f;

        // Call base function
        base.FireDirected(mineBall, originPosition, targetPosition, ballDirection, ballSpeed);

        // Fire skill
        mineBall.GetComponent<SDFireMineBehaviour>().Init(player, base.direction, damage, blastRadius);
    }
}
