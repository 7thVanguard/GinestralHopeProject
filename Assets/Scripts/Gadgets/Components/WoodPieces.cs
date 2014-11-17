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

        givesComponents = true;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        Transform woodPieces = world.woodPieces;
        woodPieces = Object.Instantiate(woodPieces, pos, Quaternion.identity) as Transform;

        // Head atributes
        woodPieces.name = "Wood Pieces";
        woodPieces.tag = "Gadget";

        // Set transforms
        woodPieces.transform.eulerAngles = rotation;
        woodPieces.transform.localScale = Gadget.Dictionary[woodPieces.name].size;
    }
}
