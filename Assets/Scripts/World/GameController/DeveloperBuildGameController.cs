using UnityEngine;
using System.Collections;

public class DeveloperBuildGameController : GameController 
{
    World world;


    public DeveloperBuildGameController(World world, GameObject player, GameObject mainCamera) : base(world, player, mainCamera)
    {
        this.world = world;
    }


    public override void Start()
    {
        inputController = new DeveloperBuildInputController(world);
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        movement.DeveloperMovementUpdate();
    }
}
