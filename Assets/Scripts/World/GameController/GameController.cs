using UnityEngine;
using System.Collections;

public class GameController 
{
    protected AbstractInputsController inputController;
    protected PlayerMovement movement;
    protected PlayerCombat combat;


    public GameController(World world, Player player, GameObject mainCamera)
    {
        movement = new PlayerMovement(player);
        combat = new PlayerCombat(player);
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
