using UnityEngine;
using System.Collections;

public class Enemy : Entity
{
	public int level;
	public int damage;

    public void PlaceEnemy(World world, Player player, MainCamera mainCamera, Vector3 pos, string ID)
    {
        if (ID == "Normal Slime")
        {
            NormalSlimeEnemy normalSlime = new NormalSlimeEnemy();
            normalSlime.PlaceEnemy(world, player, mainCamera, pos);
        }
    }
}
