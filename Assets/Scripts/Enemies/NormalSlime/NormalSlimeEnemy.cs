using UnityEngine;
using System.Collections;

public class NormalSlimeEnemy : Enemy
{
    public void Init()
    {
        ID = EnemyDictionary.Enemies["Normal Slime"].ID;
        level = EnemyDictionary.Enemies["Normal Slime"].level;
        damage = EnemyDictionary.Enemies["Normal Slime"].damage;
    }


    public void PlaceEnemy(World world, Player player, MainCamera mainCamera, Vector3 pos)
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


        // Matrix update
        //world.chunk[(int)pos.x / world.chunkSize.x, (int)(pos.y + 1) / world.chunkSize.y, (int)pos.z / world.chunkSize.z]
        //    .voxel[(int)pos.x % world.chunkSize.x, (int)(pos.y + 1) % world.chunkSize.y, (int)pos.z % world.chunkSize.z].entityType = Voxel.EntityType.ENEMY;
        //world.chunk[(int)pos.x / world.chunkSize.x, (int)(pos.y + 1) / world.chunkSize.y, (int)pos.z / world.chunkSize.z]
        //    .voxel[(int)pos.x % world.chunkSize.x, (int)(pos.y + 1) % world.chunkSize.y, (int)pos.z % world.chunkSize.z].ID = ID;
        //world.chunk[(int)pos.x / world.chunkSize.x, (int)(pos.y + 1) / world.chunkSize.y, (int)pos.z / world.chunkSize.z]
        //    .voxel[(int)pos.x % world.chunkSize.x, (int)(pos.y + 1) % world.chunkSize.y, (int)pos.z % world.chunkSize.z].position = pos;

    }
}
