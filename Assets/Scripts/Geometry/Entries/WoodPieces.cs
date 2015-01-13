using UnityEngine;
using System.Collections;

public class WoodPieces : Geometry 
{
    GameObject woodPieces;



    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        woodPieces = (GameObject)Resources.Load("Props/Geometry/Wood Pieces/Wood Pieces");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        woodPieces = GameObject.Instantiate(woodPieces, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        woodPieces.name = "Wood Pieces";
        woodPieces.tag = "Geometry";

        woodPieces.transform.localScale = scale;
        woodPieces.transform.parent = world.geometryController.transform;
    }
}
