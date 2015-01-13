using UnityEngine;
using System.Collections;

public class NormalSlimeEnemy : Enemy
{
    GameObject slime;



    public override void Init(World world, Player player, MainCamera mainCamera, Enemy enemy)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        slime = (GameObject)Resources.Load("Props/Enemies/Normal Slime/Normal Slime");

        ID = "Normal Slime";
        level = 1;
        life = 9;
        damage = 1;
    }


    public override GameObject Place(Vector3 pos)
    {
        slime = GameObject.Instantiate(slime, pos, Quaternion.identity) as GameObject;
        slime.transform.position += new Vector3(0.5f, slime.transform.localScale.y / 2, 0.5f);

        // Head atributes
        slime.name = "Normal Slime";
        slime.transform.parent = world.enemiesController.transform;

        // Components
        slime.gameObject.AddComponent<EnemyComponent>();
        slime.gameObject.AddComponent<NormalSlimeEnemyBehaviour>();
        slime.gameObject.GetComponent<NormalSlimeEnemyBehaviour>().Init(player, mainCamera, life);

        return slime.gameObject;
    }
}
