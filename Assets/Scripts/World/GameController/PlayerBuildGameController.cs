using UnityEngine;
using System.Collections;

public class PlayerBuildGameController : GameController
{
    public PlayerBuildGameController(GameObject player, GameObject mainCamera) : base(player, mainCamera)
    {

    }


    public override void Start() 
    {
        inputController = new PlayerBuildInputController();
        base.Start();
	}



    public override void Update() 
    {
        base.Update();
        movement.NormalMovementUpdate();
	}
}
