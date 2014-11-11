using UnityEngine;
using System.Collections;

public class SkillDirected : Skill
{


    public SkillDirected(string ID) : base(ID)
    {
        
    }



    public override void Cast()
    {
        //// variables
        //Vector3 originPosition;
        //Vector3 targetPosition;
        //Vector3 ballDirection;

        //// Create ball
        //GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //ball.tag = "Skill";

        //// Set transforms
        //ball.transform.position = SPlayer.transform.position;
        //ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        //// Ignoring the raycasts
        //ball.layer = LayerMask.NameToLayer("Ignore Raycast");

        //// Add components
        //ball.AddComponent<Rigidbody>();
        //ball.AddComponent<LambertBall>();
        //ball.GetComponent<Rigidbody>().useGravity = false;

        ////+ Player target selection

        //if (launchedByPlayer)
        //{
        //    // Target location
        //    if (PlayerCombat.target == null)
        //    {
        //        if (mainCamera.raycast.distance < maxDistance && mainCamera.raycast.distance != 0)
        //            targetPosition = mainCamera.raycast.point;
        //        else
        //            targetPosition = Camera.main.transform.position + Camera.main.transform.forward * maxDistance;
        //    }
        //    else
        //        targetPosition = PlayerCombat.target.transform.position;
        //}

        ////+ Enemy target selection

        //else
        //{
        //    targetPosition = SPlayer.transform.position;
        //}

        ////+ Fire

        //// Detecting initial direction
        //ballDirection = targetPosition - origin;
        //ballDirection.Normalize();
        //ballDirection *= ballSpeed;

        //// We fire in front of the caster instead of inside him
        //originPosition = origin + ballDirection.normalized * 4 / 5;

        //// Launch
        //ball.GetComponent<LambertBall>().Fire(originPosition, targetPosition, ballDirection, ballSpeed);

        base.Cast();
    }


    public override void Fire()
    {
        base.Fire();


    }
}
