using UnityEngine;
using System.Collections.Generic;

public class Skill
{
    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Skill> Dictionary;

    public string ID;
    public int objectSpeed;
    public int maxDistance;

    public float damage;
    public float blastRadius;


    public virtual void Init(World world, Player player, MainCamera mainCamera, Skill skill)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        Dictionary = new Dictionary<string, Skill>();

        //+ Fire Ball
        skill = new SDFireBall();
        skill.Init(world, player, mainCamera, skill);
        Dictionary.Add("FireBall", skill);

        skill = Dictionary["FireBall"];
    }


    public virtual void CastDirected(GameObject gameObject, Vector3 origin, bool launchedByPlayer)
    {

    }


    public virtual void FireDirected(GameObject gameObject, Vector3 originPosition, Vector3 targetPosition, Vector3 objectDirection, int objectSpeed)
    {

    }
}
