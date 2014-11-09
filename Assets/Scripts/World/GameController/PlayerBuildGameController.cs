using UnityEngine;
using System.Collections;

public class PlayerBuildGameController : GameController
{
    World world;


    public PlayerBuildGameController(World world, Player player, GameObject mainCamera) : base(world, player, mainCamera)
    {
        this.world = world;
    }


    public override void Start() 
    {
        inputController = new PlayerBuildInputController(world);
        base.Start();
	}



    public override void Update() 
    {
        base.Update();
        movement.NormalMovementUpdate();
	}
}
