using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyDictionary 
{
	public static Dictionary<string, Enemy> Enemies = new Dictionary<string, Enemy>();
	
	
    public EnemyDictionary()
    {
        Enemies = new Dictionary<string, Enemy>();
        Init();
    }


	private void Init()
	{
		//+ Normal SLime
		NormalSlimeEnemy normalSlime = new NormalSlimeEnemy();
		
		normalSlime.ID = "Normal Slime";
		normalSlime.level = 1;
		normalSlime.damage = 1;
		
		Enemies.Add(normalSlime.ID, normalSlime);
        normalSlime.Init();
	}
}
