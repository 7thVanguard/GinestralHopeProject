using UnityEngine;
using System.Collections;

public class DeveloperBuildGameController : GameController 
{
    public DeveloperBuildGameController(GameObject player, GameObject mainCamera) : base(player, mainCamera)
    {

    }


    public override void Start()
    {
        inputController = new DeveloperBuildInputController();
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        movement.DeveloperMovementUpdate();
    }
}
