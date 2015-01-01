using UnityEngine;
using System.Collections;

public class CloudCollider : Geometry
{
    Transform cloudCollider;


    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.AIR;

        cloudCollider = world.geometry.FindChild("Cloud Collider");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        cloudCollider = Object.Instantiate(cloudCollider, pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        cloudCollider.name = "Cloud Collider";
        cloudCollider.tag = "Geometry";

        cloudCollider.transform.localScale = scale;
        cloudCollider.transform.parent = world.geometryController.transform;
    }
}
