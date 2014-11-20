using UnityEngine;
using System.Collections;

public class DeveloperGameController : GameController 
{
    private World world;
    private Player player;
    private MainCamera mainCamera;


    public DeveloperGameController(World world, Player player, MainCamera mainCamera) : base(world, player, mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        inputController = new DeveloperInputController(world, player, mainCamera);
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        playerMovement.DeveloperMovementUpdate();
        cameraMovement.Update();
        cameraRaycast.Update();
    }
}
