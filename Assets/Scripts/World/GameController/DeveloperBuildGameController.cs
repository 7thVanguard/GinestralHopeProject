using UnityEngine;
using System.Collections;

public class DeveloperBuildGameController : GameController 
{
    private World world;
    private Player player;


    public DeveloperBuildGameController(World world, Player player, GameObject mainCamera) : base(world, player, mainCamera)
    {
        this.world = world;
        this.player = player;
    }


    public override void Start()
    {
        inputController = new DeveloperBuildInputController(world, player);
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        movement.DeveloperMovementUpdate();
    }
}
