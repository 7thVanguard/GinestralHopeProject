using UnityEngine;
using System.Collections;

public class SDFireBall : SkillDirected
{
    public SDFireBall(string ID)  : base(ID)
    {
        base.ID = ID;
    }


    public override GameObject CastDirected(MainCamera mainCamera, GameObject fireBall, Vector3 origin, int ballSpeed, int maxDistance, bool launchedByPlayer)
    {
        fireBall = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        fireBall = base.CastDirected(mainCamera, fireBall, origin, ballSpeed, maxDistance, launchedByPlayer);
        FireDirected(fireBall, base.originPosition, base.targetPosition, base.objectDirection, ballSpeed);

        return fireBall;
    }


    public override void FireDirected(GameObject fireBall, Vector3 originPosition, Vector3 targetPosition, Vector3 ballDirection, int ballSpeed)
    {
        // Set transforms
        fireBall.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // Set components
        fireBall.AddComponent<FireBallBehaviour>();
        fireBall.GetComponent<Rigidbody>().useGravity = false;

        base.FireDirected(fireBall, originPosition, targetPosition, ballDirection, ballSpeed);
    }
}
