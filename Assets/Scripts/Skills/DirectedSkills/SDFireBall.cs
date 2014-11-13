using UnityEngine;
using System.Collections;

public class SDFireBall : SkillDirected
{
    public SDFireBall(string ID)  : base(ID)
    {
        
    }


    public void Init()
    {
        ID = SkillDictionary.Skills["FireBall"].ID;
        objectSpeed = SkillDictionary.Skills["FireBall"].objectSpeed;
        maxDistance = SkillDictionary.Skills["FireBall"].maxDistance;
    }


    public override GameObject CastDirected(Player player, MainCamera mainCamera, GameObject fireBall, Vector3 origin, bool launchedByPlayer)
    {
        fireBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        fireBall = base.CastDirected(player, mainCamera, fireBall, origin, launchedByPlayer);
        FireDirected(fireBall, base.originPosition, base.targetPosition, base.objectDirection, objectSpeed);

        return fireBall;
    }


    public override void FireDirected(GameObject fireBall, Vector3 originPosition, Vector3 targetPosition, Vector3 ballDirection, int ballSpeed)
    {
        // Set transforms
        fireBall.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Set components
        fireBall.AddComponent<SDFireBallBehaviour>();
        fireBall.GetComponent<Rigidbody>().useGravity = false;

        base.FireDirected(fireBall, originPosition, targetPosition, ballDirection, ballSpeed);
    }
}
