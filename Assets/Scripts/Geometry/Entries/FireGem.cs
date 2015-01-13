using UnityEngine;
using System.Collections;

public class FireGem : Geometry
{
    GameObject fireGem;



    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        fireGem = (GameObject)Resources.Load("Props/Geometry/Fire Gem/Fire Gem");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        fireGem = GameObject.Instantiate(fireGem, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        fireGem.name = "Fire Gem";
        fireGem.tag = "Geometry";

        fireGem.transform.localScale = scale;
        fireGem.transform.parent = world.geometryController.transform;
    }
}
