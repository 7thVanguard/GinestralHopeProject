using UnityEngine;
using System.Collections;

public class Skill
{
    protected string ID;

    public virtual GameObject CastDirected(MainCamera mainCamera, GameObject gameObject, Vector3 origin, int ballSpeed, int maxDistance, bool launchedByPlayer)
    {
        return null;
    }


    public virtual void FireDirected(GameObject gameObject, Vector3 originPosition, Vector3 targetPosition, Vector3 objectDirection, int objectSpeed)
    {

    }
}
