using UnityEngine;
using System.Collections;

public class Chest : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Chest";

        size = new Vector3(1, 1, 1);
        count = 0;

        placedOnFloor = true;

        givesComponents = false;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        Transform chest = Object.Instantiate(world.gadgets.FindChild("Chest"), pos, Quaternion.identity) as Transform;

        // Head atributes
        chest.name = "Chest";
        chest.tag = "Gadget";
        chest.transform.parent = world.gadgetsController.transform;

        // Set transforms
        chest.transform.eulerAngles = Vector3.zero;
    }
}
