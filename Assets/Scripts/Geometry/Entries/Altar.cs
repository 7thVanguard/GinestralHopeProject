using UnityEngine;
using System.Collections;

public class Altar : Geometry 
{
    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        Transform altar = Object.Instantiate(world.interactives.FindChild("Altar"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        altar.name = "Altar";
        altar.tag = "Geometry";

        altar.transform.localScale = scale;
        altar.transform.parent = world.geometryController.transform;
    }
}
