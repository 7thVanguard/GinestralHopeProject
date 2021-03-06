﻿using UnityEngine;
using System.Collections;

/*
 * Enemy Type:      Basic.
 * Movement         Static.
 *  Attack          Distance;   parabolic ball.
 *  Drop            Nothing by now.
*/

public class NormalSlimeEnemyBehaviour : MonoBehaviour 
{
    Player player;
    MainCamera mainCamera;

    // Movement relative
    private NSlimeEnemyMovement movement;

    // Combat relative
    private NSlimeEnemyCombat combat;


    public void Init(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;

        // Movement relative
        movement = new NSlimeEnemyMovement();

        // Combat relative
        int maxLife = 3;

        combat = new NSlimeEnemyCombat();
        this.gameObject.GetComponent<EnemyComponent>().life = maxLife;
        this.gameObject.GetComponent<EnemyComponent>().maxLife = maxLife;

        // Updates
        movement.Start(gameObject);
        combat.Init(player, gameObject);
    }
	

	void FixedUpdate ()
    {
        if (!EGameFlow.pause)
        {
            movement.Update();
            combat.Update(mainCamera, gameObject);
        }
	}
}
