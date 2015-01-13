using UnityEngine;
using System.Collections;

public class Torch : Geometry
{
    GameObject torch;



    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.WALL;

        torch = (GameObject)Resources.Load("Props/Geometry/Torch/Torch");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        torch = GameObject.Instantiate(torch, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        torch.name = "Torch";
        torch.tag = "Geometry";

        torch.transform.localScale = scale;
        torch.transform.parent = world.geometryController.transform;
    }
}
