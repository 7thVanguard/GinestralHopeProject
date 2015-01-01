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
        skillTrajectory = Skill.SkillTrajectory.LINEAR;
        objectSpeed = 25;
        maxDistance = 30;

        // Cast
        castingTime = 0.5f;
        coolDown = 0.5f;

        // Fire
        damage = 4;
        blastRadius = 6;
    }


    public override void CastDirected(GameObject fireBall, Vector3 origin, bool launchedByPlayer)
    {
        switch (GameFlow.runningGame)
        {
            case GameFlow.RunningGame.GINESTRAL_HOPE:
                skillTrajectory = Skill.SkillTrajectory.PARABOLIC;
                break;
            case GameFlow.RunningGame.CLOUDS_SIGHT:
                skillTrajectory = Skill.SkillTrajectory.LINEAR;
                break;
            case GameFlow.RunningGame.PLANNED_DREAM:
                skillTrajectory = Skill.SkillTrajectory.PARABOLIC;
                break;
            default:
                break;
        }

        // Create the object
        Transform fireBallTransform = Object.Instantiate(world.skills.FindChild("Fire Ball")) as Transform;
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
        fireBall.GetComponent<SDFireBallBehaviour>().Init(base.world, base.direction, damage, blastRadius);
    }
}
