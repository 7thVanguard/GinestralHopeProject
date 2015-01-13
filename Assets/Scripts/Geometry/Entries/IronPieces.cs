using UnityEngine;
using System.Collections;

public class IronPieces : Geometry 
{
    GameObject ironPieces;



    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        ironPieces = (GameObject)Resources.Load("Props/Geometry/Iron Pieces/Iron Pieces");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        ironPieces = GameObject.Instantiate(ironPieces, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        ironPieces.name = "Iron Pieces";
        ironPieces.tag = "Geometry";

        ironPieces.transform.localScale = scale;
        ironPieces.transform.parent = world.geometryController.transform;
    }
}
