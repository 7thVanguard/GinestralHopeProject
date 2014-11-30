using UnityEngine;
using System.Collections;

public class WoodPieces : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Wood Pieces";

        size = new Vector3(1, 1, 1);
        count = 0;

        placedOnFloor = true;

        givesComponents = true;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        Transform woodPieces = Object.Instantiate(world.gadgets.FindChild("Wood Pieces"), pos, Quaternion.identity) as Transform;

        // Head atributes
        woodPieces.name = "Wood Pieces";
        woodPieces.tag = "Gadget";
        woodPieces.transform.parent = world.gadgetsController.transform;
    }
}
