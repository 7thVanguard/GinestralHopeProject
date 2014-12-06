using UnityEngine;
using System.Collections;

public class Chest : Geometry 
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
        Transform chest = Object.Instantiate(world.gadgets.FindChild("Chest"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        chest.name = "Chest";
        chest.tag = "Geometry";

        chest.transform.localScale = scale;
        chest.transform.parent = world.geometryController.transform;
    }
}
