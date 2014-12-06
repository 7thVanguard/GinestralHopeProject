using UnityEngine;
using System.Collections;

public class IronPieces : Geometry 
{
    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale)
    {
        Transform ironPieces = Object.Instantiate(world.gadgets.FindChild("Iron Pieces"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        ironPieces.name = "Iron Pieces";
        ironPieces.tag = "Geometry";

        ironPieces.transform.localScale = scale;
        ironPieces.transform.parent = world.geometryController.transform;
    }
}
