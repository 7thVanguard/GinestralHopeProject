using UnityEngine;
using System.Collections;

/*
 * Enemy Type:      Basic.
 * Movement         Static.
 *  Attack          Distance;   parabolic ball.
 *  Drop            Nothing by now.
*/

public class UNSlime : MonoBehaviour 
{
    // Movement relative
    private NSlimeMovement movement;

    // Combat relative
    private NSlimeCombat combat;
    

	void Awake ()
    {
        // Movement relative
        movement = new NSlimeMovement();

        // Combat relative
        combat = new NSlimeCombat();

        this.gameObject.GetComponent<EnemyComponent>().life = SNSlime.maxLife;
        this.gameObject.GetComponent<EnemyComponent>().maxLife = SNSlime.maxLife;

        movement.Start(gameObject);
        combat.Start(gameObject);
	}
	

	void FixedUpdate ()
    {
        if (!EGameFlow.pause && UWorldGenerator.gameLoaded)
        {
            movement.Update();

            //combat.Update(mainCamera, gameObject);
        }
	}
}
