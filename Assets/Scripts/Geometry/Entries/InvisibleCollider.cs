using UnityEngine;
using System.Collections;

public class InvisibleCollider : Geometry
{
    Transform invisibleCollider;


    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.AIR;

        invisibleCollider = world.geometry.FindChild("Invisible Collider");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        invisibleCollider = Object.Instantiate(invisibleCollider, pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        invisibleCollider.name = "Invisible Collider";
        invisibleCollider.tag = "Geometry";

        invisibleCollider.transform.localScale = scale;
        invisibleCollider.transform.parent = world.geometryController.transform;
    }
}
