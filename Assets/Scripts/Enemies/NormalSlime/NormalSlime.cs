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


    public void PlaceEnemy(World world, Player player, MainCamera mainCamera, Vector3 position)
    {
        Transform enemy = world.normalSlime;

        enemy = Object.Instantiate(enemy, position, Quaternion.identity) as Transform;

        // Head atributes
        enemy.name = "Normal Slime";

        // Components
        enemy.gameObject.AddComponent<EnemyComponent>();
        enemy.gameObject.AddComponent<NormalSlimeBehaviour>();
        enemy.gameObject.GetComponent<NormalSlimeBehaviour>().Init(player, mainCamera);
    }
}
