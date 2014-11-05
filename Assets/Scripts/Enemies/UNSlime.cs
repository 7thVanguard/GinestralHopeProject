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
    NSlimeMovement movement;

    // Combat relative
    NSlimeCombat combat;
    

	void Awake ()
    {
        // Movement relative
        movement = new NSlimeMovement();

        // Combat relative
        combat = new NSlimeCombat();

        this.gameObject.GetComponent<EnemyComponent>().life = SNSlime.maxLife;
        this.gameObject.GetComponent<EnemyComponent>().originalColor = gameObject.renderer.material.color;

        movement.Start(gameObject);
        combat.Start(gameObject);
	}
	

	void Update () 
    {
        InvokeRepeating("Detection", 0, 0.5f);

        if (!EGameFlow.pause && UWorldGenerator.gameLoaded)
        {
            movement.Update();
            combat.Update();
        }
	}


    public void Detection()
    {
        Debug.Log("pass");
    }
}
