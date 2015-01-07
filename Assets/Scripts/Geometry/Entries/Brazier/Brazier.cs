using UnityEngine;
using System.Collections;

public class Brazier : Geometry
{
    Transform brazier;

    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        brazier = Object.Instantiate(world.geometry.FindChild("Brazier"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        brazier.name = "Brazier";
        brazier.tag = "Geometry";

        brazier.transform.localScale = scale;
        brazier.transform.parent = world.geometryController.transform;
    }
}
