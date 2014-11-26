using UnityEngine;
using System.Collections;

public class IronPieces : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Iron Pieces";

        size = new Vector3(1, 1, 1);
        count = 0;

        givesComponents = true;
        dropCount = 4;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        Transform ironPieces = world.gadgets;
        ironPieces = Object.Instantiate(world.gadgets.FindChild("Iron Pieces"), pos, Quaternion.identity) as Transform;

        // Head atributes
        ironPieces.name = "Iron Pieces";
        ironPieces.tag = "Gadget";

        // Set transforms
        ironPieces.transform.eulerAngles = Vector3.zero;
        ironPieces.transform.localScale = Gadget.Dictionary[ironPieces.name].size;
    }
}
