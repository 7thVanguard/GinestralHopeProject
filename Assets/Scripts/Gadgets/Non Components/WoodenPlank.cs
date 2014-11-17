using UnityEngine;
using System.Collections;

public class WoodenPlank : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Wooden Planks";

        size = new Vector3(1, 0.1f, 6);
        count = 0;

        givesComponents = false;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        GameObject plank = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Head atributes
        plank.name = "Wooden Plank";
        plank.tag = "Gadget";

        // Set transforms
        plank.transform.position = pos;
        plank.transform.eulerAngles = rotation;
        plank.transform.localScale = Gadget.Dictionary[plank.name].size;
    }
}
