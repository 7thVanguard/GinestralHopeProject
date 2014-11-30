using UnityEngine;
using System.Collections;

public class FireGem : Gadget
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Fire Gem";

        size = new Vector3(1, 1, 1);
        count = 0;

        placedOnFloor = true;

        givesComponents = false;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        Transform fireGem = Object.Instantiate(world.gadgets.FindChild("FireGem"), pos, Quaternion.identity) as Transform;

        // Head atributes
        fireGem.name = "Fire Gem";
        fireGem.tag = "Gadget";
        fireGem.transform.parent = world.gadgetsController.transform;
    }
}
