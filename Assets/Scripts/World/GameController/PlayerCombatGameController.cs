using UnityEngine;
using System.Collections;

public class PlayerCombatGameController : GameController 
{
    public PlayerCombatGameController(World world, Player player, GameObject mainCamera) : base(world, player, mainCamera)
    {

    }


    public override void Start()
    {
        inputController = new PlayerCombatInputController();
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        movement.NormalMovementUpdate();
        combat.Update();
    }
}
