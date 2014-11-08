using UnityEngine;
using System.Collections;

public class LEnemy : MonoBehaviour 
{
    public static void placeNormalSlime(Vector3 position)
    {
        if (EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
        {
            Transform enemy = SWorld.normalSlime;

            enemy = Object.Instantiate(enemy, position, Quaternion.identity) as Transform;
            enemy.name = "Normal Slime";
        }
    }
}
