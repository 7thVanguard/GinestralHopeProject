using UnityEngine;
using System.Collections;

public class PlayerCombatGameController : GameController 
{
    public PlayerCombatGameController(GameObject player, GameObject mainCamera) : base(player, mainCamera)
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
    }
}
