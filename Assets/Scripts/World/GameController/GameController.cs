using UnityEngine;
using System.Collections;

public class GameController 
{
    protected AbstractInputsController inputController;
    protected PlayerMovement movement;


    public GameController(World world, GameObject player, GameObject mainCamera)
    {
        movement = new PlayerMovement(player);
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
