using UnityEngine;
using System.Collections;

public class NormalSlime : Enemy
{
    public void Init()
    {
        ID = EnemyDictionary.EnemiesDictionary["Normal Slime"].ID;
        level = EnemyDictionary.EnemiesDictionary["Normal Slime"].level;
        damage = EnemyDictionary.EnemiesDictionary["Normal Slime"].damage;
    }


    public void PlaceEnemy()
    {

    }
}
