using UnityEngine;
using System.Collections;

public class Torch : Gadget
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Torch";

        size = new Vector3(1, 0.1f, 6);
        count = 0;

        givesComponents = false;
        dropCount = 1;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        GameObject torch = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Head atributes
        torch.name = "Torch";
        torch.tag = "Gadget";

        // Set transforms
        torch.transform.position = pos;
        torch.transform.eulerAngles = rotation;
        torch.transform.localScale = Gadget.Dictionary[torch.name].size;
    }
}
