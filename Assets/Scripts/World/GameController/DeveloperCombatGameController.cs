using UnityEngine;
using System.Collections;

public class DeveloperCombatGameController : GameController
{
    private Player player;
    private MainCamera mainCamera;


    public DeveloperCombatGameController(World world, Player player, MainCamera mainCamera) : base(world, player, mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        inputController = new DeveloperCombatInputController(player, mainCamera);
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        playerMovement.DeveloperMovementUpdate();
        playerCombat.Update();
        cameraMovement.Update();
        cameraRaycast.Update();
    }
}
