using UnityEngine;
using System.Collections;

public class SDFireBall : SkillDirected
{
    public override void Init(World world, Player player, MainCamera mainCamera, Skill skill)
    {
        base.world = world;
        base.player = player;
        base.mainCamera = mainCamera;

        // Global
        ID = "Fire Ball";

        // Flight
        skillTrajectory = Skill.SkillTrajectory.PARABOLIC;
        objectSpeed = 25;
        maxDistance = 30;

        // CAst
        castingTime = 2;

        // Fire
        damage = 3;
        blastRadius = 3;
    }


    public override void CastDirected(GameObject fireBall, Vector3 origin, bool launchedByPlayer)
    {
        // Create the object
        Transform fireBallTransform = Object.Instantiate(world.skills.FindChild("Fireball1")) as Transform;
        fireBall = fireBallTransform.gameObject;
        fireBall.name = "Fire Ball";

        // Call base function
        base.CastDirected(fireBall, origin, launchedByPlayer);

        // Call next function
        FireDirected(fireBall, base.originPosition, base.targetPosition, base.objectDirection, objectSpeed);
    }


    public override void FireDirected(GameObject fireBall, Vector3 originPosition, Vector3 targetPosition, Vector3 ballDirection, int ballSpeed)
    {
        // Set transforms
        fireBall.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Set components
        fireBall.AddComponent<SDFireBallBehaviour>();
        fireBall.GetComponent<Rigidbody>().useGravity = false;

        // Call base function
        base.FireDirected(fireBall, originPosition, targetPosition, ballDirection, ballSpeed);

        // Fire skill
        fireBall.GetComponent<SDFireBallBehaviour>().Init(base.direction, damage, blastRadius);
    }
}
