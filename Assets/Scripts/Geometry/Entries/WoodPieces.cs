using UnityEngine;
using System.Collections;

public class WoodPieces : Geometry 
{
    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
        size = new Vector3(1, 1, 1);
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot)
    {
        Transform woodPieces = Object.Instantiate(world.gadgets.FindChild("Wood Pieces"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        woodPieces.name = "Wood Pieces";
        woodPieces.tag = "Geometry";
        woodPieces.transform.parent = world.gadgetsController.transform;
    }
}
