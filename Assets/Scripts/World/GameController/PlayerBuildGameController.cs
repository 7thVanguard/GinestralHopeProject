using UnityEngine;
using System.Collections;

public class PlayerBuildGameController : GameController
{
    public PlayerBuildGameController(World world, GameObject player, GameObject mainCamera) : base(world, player, mainCamera)
    {

    }


    public override void Start() 
    {
        inputController = new PlayerBuildInputController();
        base.Start();
	}



    public override void Update() 
    {
        base.Update();
        movement.NormalMovementUpdate();
	}
}
