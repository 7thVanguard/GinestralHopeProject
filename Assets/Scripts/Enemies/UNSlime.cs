using UnityEngine;
using System.Collections;

public class UNSlime : MonoBehaviour 
{
    // Movement relative
    NSlimeMovement movement;


	void Awake ()
    {
        // Movement relative
        movement = new NSlimeMovement();

        this.gameObject.GetComponent<EnemyComponent>().life = SNSlime.maxLife;
        this.gameObject.GetComponent<EnemyComponent>().originalColor = gameObject.renderer.material.color;

        movement.Start(gameObject);
	}
	

	void Update () 
    {
        if (!EGameFlow.pause && UWorldGenerator.gameLoaded)
            movement.Update();
	}
}
