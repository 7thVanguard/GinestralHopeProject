using UnityEngine;
using System.Collections;

public class DeveloperCombatGameController : GameController
{
    public DeveloperCombatGameController(World world, GameObject player, GameObject mainCamera) : base(world, player, mainCamera)
    {

    }


    public override void Start()
    {
        inputController = new DeveloperCombatInputController();
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        movement.DeveloperMovementUpdate();
    }
}
