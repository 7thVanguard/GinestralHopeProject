using UnityEngine;
using System.Collections;

public class PlayerCombatGameController : GameController 
{
    Player player;


    public PlayerCombatGameController(World world, Player player, GameObject mainCamera) : base(world, player, mainCamera)
    {
        this.player = player;
    }


    public override void Start()
    {
        inputController = new PlayerCombatInputController(player);
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        movement.NormalMovementUpdate();
        combat.Update();
    }
}
