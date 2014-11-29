using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy
{
    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Enemy> Dictionary;

    public string ID;
	public int level;
    public int life;
	public int damage;


    public virtual void Init(World world, Player player, MainCamera mainCamera, Enemy enemy)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        Dictionary = new Dictionary<string, Enemy>();

        //+ Normal Slime
        enemy = new NormalSlimeEnemy();
        enemy.Init(world, player, mainCamera, enemy);
        Dictionary.Add("Normal Slime", enemy);

        enemy = Dictionary["Normal Slime"];
    }


    public virtual GameObject Place(Vector3 pos)
    {
        return null;
    }
}
