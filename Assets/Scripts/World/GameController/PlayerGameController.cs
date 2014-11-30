using UnityEngine;
using System.Collections;

public class PlayerGameController : GameController
{
    private World world;
    private Player player;
    private MainCamera mainCamera;


    public PlayerGameController(World world, Player player, MainCamera mainCamera) : base(world, player, mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start() 
    {
        inputController = new PlayerInputController(world, player, mainCamera);
        base.Start();
	}



    public override void Update() 
    {
        base.Update();

        if (!EGameFlow.pause)
        {
            playerMovement.NormalMovementUpdate();
            playerCombat.Update();
            cameraMovement.Update();
            cameraRaycast.Update();
        }
	}
}
