using UnityEngine;
using System.Collections;

public class Brazier : Geometry
{
    GameObject brazier;



    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        brazier = (GameObject)Resources.Load("Props/Geometry/Brazier/Brazier");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        brazier = GameObject.Instantiate(brazier, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        brazier.name = "Brazier";
        brazier.tag = "Geometry";

        brazier.transform.localScale = scale;
        brazier.transform.parent = world.geometryController.transform;
    }
}
