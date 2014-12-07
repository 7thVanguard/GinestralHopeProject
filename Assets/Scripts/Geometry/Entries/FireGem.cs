using UnityEngine;
using System.Collections;

public class FireGem : Geometry
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
        Transform fireGem = Object.Instantiate(world.gadgets.FindChild("FireGem"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        fireGem.name = "Fire Gem";
        fireGem.tag = "Geometry";

        fireGem.transform.localScale = scale;
        fireGem.transform.parent = world.geometryController.transform;
    }
}
