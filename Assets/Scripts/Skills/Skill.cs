using UnityEngine;
using System.Collections;

public class Skill
{
    public string ID;
    public int objectSpeed;
    public int maxDistance;


    public virtual GameObject CastDirected(Player player, MainCamera mainCamera, GameObject gameObject, Vector3 origin, bool launchedByPlayer)
    {
        return null;
    }


    public virtual void FireDirected(GameObject gameObject, Vector3 originPosition, Vector3 targetPosition, Vector3 objectDirection, int objectSpeed)
    {

    }
}
