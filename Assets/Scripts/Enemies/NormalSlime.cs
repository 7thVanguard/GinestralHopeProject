using UnityEngine;
using System.Collections;

public class NormalSlime : Enemy
{
    public void Init()
    {
        ID = EnemyDictionary.Enemies["Normal Slime"].ID;
        level = EnemyDictionary.Enemies["Normal Slime"].level;
        damage = EnemyDictionary.Enemies["Normal Slime"].damage;
    }


    public void PlaceEnemy(World world, Vector3 position)
    {
        Transform enemy = world.normalSlime;

        enemy = Object.Instantiate(enemy, position, Quaternion.identity) as Transform;
        enemy.name = "Normal Slime";
    }
}
