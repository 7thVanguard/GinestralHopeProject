using UnityEngine;
using System.Collections;

public class Torch : Geometry
{
    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.WALL;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        Transform torch = Object.Instantiate(world.gadgets.FindChild("Torch"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        torch.name = "Torch";
        torch.tag = "Geometry";

        torch.transform.localScale = scale;
        torch.transform.parent = world.geometryController.transform;
    }
}
