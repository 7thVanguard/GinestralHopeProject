using UnityEngine;
using System.Collections;

public class NormalSlimeEnemy : Enemy
{
    public override void Init(World world, Player player, MainCamera mainCamera, Enemy enemy)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Normal Slime";
        level = 1;
        damage = 1;
    }


    public override void Place(Vector3 pos)
    {
        Transform enemy = world.normalSlime;

        enemy = Object.Instantiate(enemy, pos, Quaternion.identity) as Transform;
        enemy.position += new Vector3(0.5f, enemy.localScale.y / 2, 0.5f);

        // Head atributes
        enemy.name = "Normal Slime";

        // Components
        enemy.gameObject.AddComponent<EnemyComponent>();
        enemy.gameObject.AddComponent<NormalSlimeEnemyBehaviour>();
        enemy.gameObject.GetComponent<NormalSlimeEnemyBehaviour>().Init(player, mainCamera);
    }
}
