using UnityEngine;
using System.Collections;

public class DeveloperCombatGameController : GameController
{
    Player player;


    public DeveloperCombatGameController(World world, Player player, GameObject mainCamera) : base(world, player, mainCamera)
    {
        this.player = player;
    }


    public override void Start()
    {
        inputController = new DeveloperCombatInputController(player);
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        movement.DeveloperMovementUpdate();
        combat.Update();
    }
}
