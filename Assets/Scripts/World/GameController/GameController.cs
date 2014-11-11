using UnityEngine;
using System.Collections;

public class GameController 
{
    protected AbstractInputsController inputController;
    protected PlayerMovement playerMovement;
    protected PlayerCombat playerCombat;
    protected CameraMovement cameraMovement;
    protected CameraRaycast cameraRaycast;


    public GameController(World world, Player player, MainCamera mainCamera)
    {
        playerMovement = new PlayerMovement(player);
        playerCombat = new PlayerCombat(player, mainCamera);
        cameraMovement = new CameraMovement(player, mainCamera);
        cameraRaycast = new CameraRaycast(mainCamera);
    }


    public virtual void Start()
    {
        inputController.Start();
    }


    public virtual void Update()
    {
        inputController.Update();
    }
}
