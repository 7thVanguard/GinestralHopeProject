using UnityEngine;
using System.Collections;

public class PlayerCombatGameController : GameController 
{
    private Player player;
    private MainCamera mainCamera;


    public PlayerCombatGameController(World world, Player player, MainCamera mainCamera) : base(world, player, mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        inputController = new PlayerCombatInputController(player);
        base.Start();
    }



    public override void Update()
    {
        base.Update();
        playerMovement.NormalMovementUpdate();
        playerCombat.Update();
        cameraMovement.Update();
    }
}
