using UnityEngine;
using System.Collections;

public class Bomb : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Bomb";

        size = new Vector3(1, 1, 1);
        count = 0;

        placedOnFloor = true;

        givesComponents = false;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        if (Gadget.Dictionary["Bomb"].count >= 1 || EGameFlow.gameMode != EGameFlow.GameMode.PLAYER)
        {
            Transform bomb = Object.Instantiate(world.gadgets.FindChild("Bomb"), pos, Quaternion.identity) as Transform;

            // Head atributes
            bomb.name = "Bomb";
            bomb.tag = "Gadget";
            bomb.transform.parent = world.gadgetsController.transform;

            // Set transforms
            bomb.transform.position = new Vector3(pos.x, pos.y, pos.z);
            bomb.gameObject.AddComponent<BombBehaviour>();
            bomb.gameObject.GetComponent<BombBehaviour>().Init(world);

            if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
            {
                // Remove the plank from the inventory
                Gadget.Dictionary["Bomb"].count--;
            }
        }
    }
}
