using UnityEngine;
using System.Collections;

public class PlayerBuildGameController : GameController
{
    World world;
    Player player;


    public PlayerBuildGameController(World world, Player player, GameObject mainCamera) : base(world, player, mainCamera)
    {
        this.world = world;
        this.player = player;
    }


    public override void Start() 
    {
        inputController = new PlayerBuildInputController(world, player);
        base.Start();
	}



    public override void Update() 
    {
        base.Update();
        movement.NormalMovementUpdate();
	}
}
