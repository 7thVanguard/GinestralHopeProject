using UnityEngine;
using System.Collections;

public class PlayerBuildGameController : GameController
{
    private World world;
    private Player player;
    private MainCamera mainCamera;


    public PlayerBuildGameController(World world, Player player, MainCamera mainCamera) : base(world, player, mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start() 
    {
        inputController = new PlayerBuildInputController(world, player);
        base.Start();
	}



    public override void Update() 
    {
        base.Update();
        playerMovement.NormalMovementUpdate();
        cameraMovement.Update();
	}
}
