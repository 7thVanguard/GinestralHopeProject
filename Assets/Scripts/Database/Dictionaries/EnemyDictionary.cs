using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyDictionary : MonoBehaviour 
{
	public static Dictionary<string, Enemy> EnemiesDictionary = new Dictionary<string, Enemy>();
	
	
	void Awake()
	{
		//+ Normal SLime
		Enemy normalSlime = new Enemy();
		
		normalSlime.nameKey = "Wooden Plank";
		normalSlime.level = 1;
		normalSlime.damage = 1;
		
		EnemiesDictionary.Add(normalSlime.nameKey, normalSlime);
	}
}
