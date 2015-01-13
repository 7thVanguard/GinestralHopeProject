using UnityEngine;
using System.Collections;

public class SDFrostBolt : SkillDirected
{
    GameObject frostBolt;



    public override void Init(World world, Player player, MainCamera mainCamera, Skill skill)
    {
        base.world = world;
        base.player = player;
        base.mainCamera = mainCamera;

        frostBolt = (GameObject)Resources.Load("Props/Skills/Frost Ball/Frost Ball");

        // Global
        ID = "Frost Bolt";

        // Flight
        skillTrajectory = Skill.SkillTrajectory.LINEAR;
        objectSpeed = 25;
        maxDistance = 30;

        // Cast
        castingTime = 0.1f;

        // Fire
        damage = 1;
        blastRadius = 0;
    }


    public override void CastDirected(GameObject frostBolt, Vector3 origin, bool launchedByPlayer)
    {
        // Create the object
        frostBolt = GameObject.Instantiate(this.frostBolt) as GameObject;
        frostBolt.name = "Frost Bolt";

        // Call base function
        base.CastDirected(frostBolt, origin, launchedByPlayer);

        // Call next function
        FireDirected(frostBolt, base.originPosition, base.targetPosition, base.objectDirection, objectSpeed);
    }


    public override void FireDirected(GameObject frostBall, Vector3 originPosition, Vector3 targetPosition, Vector3 ballDirection, int ballSpeed)
    {
        // Set transforms
        frostBall.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Set components
        frostBall.AddComponent<SDFrostBoltBehaviour>();
        frostBall.GetComponent<Rigidbody>().useGravity = false;

        // Call base function
        base.FireDirected(frostBall, originPosition, targetPosition, ballDirection, ballSpeed);

        // Fire skill
        frostBall.GetComponent<SDFrostBoltBehaviour>().Init(base.world, base.direction, damage, blastRadius);
    }
}
