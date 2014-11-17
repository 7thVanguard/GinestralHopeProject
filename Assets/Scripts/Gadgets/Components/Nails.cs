using UnityEngine;
using System.Collections;

public class Nails : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Nails";

        size = new Vector3(1, 1, 1);
        count = 0;

        givesComponents = true;
        dropCount = 4;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        Transform nails = world.nails;
        nails = Object.Instantiate(nails, pos, Quaternion.identity) as Transform;

        // Head atributes
        nails.name = "Nails";
        nails.tag = "Gadget";

        // Set transforms
        nails.transform.eulerAngles = rotation;
        nails.transform.localScale = Gadget.Dictionary[nails.name].size;
    }
}
