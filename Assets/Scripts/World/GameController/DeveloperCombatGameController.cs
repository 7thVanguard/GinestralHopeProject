using UnityEngine;
using System.Collections;

public class DeveloperCombatGameController : GameController
{
    public DeveloperCombatGameController(GameObject player, GameObject mainCamera) : base(player, mainCamera)
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
