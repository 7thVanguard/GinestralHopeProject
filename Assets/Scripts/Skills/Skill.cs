using UnityEngine;
using System.Collections.Generic;

public class Skill
{
    public enum SkillTrajectory { INSTANT, LINEAR, PARABOLIC }

    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Skill> Dictionary;

    // Global
    public string ID;

    // Flight
    public SkillTrajectory skillTrajectory;
    protected int objectSpeed;
    protected int maxDistance;

    // Cast // In seconds
    public float castingTime;
    public float coolDown;

    // Fire
    public int blastRadius;
    public float damage;
    


    public virtual void Init(World world, Player player, MainCamera mainCamera, Skill skill)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        Dictionary = new Dictionary<string, Skill>();

        //+ Frost Ball
        skill = new SDFrostBolt();
        skill.Init(world, player, mainCamera, skill);
        Dictionary.Add("Frost Bolt", skill);

        //+ Fire Ball
        skill = new SDFireBall();
        skill.Init(world, player, mainCamera, skill);
        Dictionary.Add("Fire Ball", skill);

        //+ Fire Mine
        skill = new SDFireMine();
        skill.Init(world, player, mainCamera, skill);
        Dictionary.Add("Fire Mine", skill);

        skill = Dictionary["Fire Ball"];
    }


    public virtual void CastDirected(GameObject gameObject, Vector3 origin, bool launchedByPlayer)
    {

    }


    public virtual void FireDirected(GameObject gameObject, Vector3 originPosition, Vector3 targetPosition, Vector3 objectDirection, int objectSpeed)
    {

    }
}
