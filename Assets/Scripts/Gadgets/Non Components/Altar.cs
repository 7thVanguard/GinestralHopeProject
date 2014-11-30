using UnityEngine;
using System.Collections;

public class Altar : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Iron Pieces";

        size = new Vector3(1, 1, 1);
        count = 0;

        placedOnFloor = true;

        givesComponents = false;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        Transform altar = Object.Instantiate(world.gadgets.FindChild("Altar"), pos, Quaternion.identity) as Transform;

        // Head atributes
        altar.name = "Altar";
        altar.tag = "Gadget";
        altar.transform.parent = world.gadgetsController.transform;
    }
}
