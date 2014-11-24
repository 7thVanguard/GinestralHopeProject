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
        if (Gadget.Dictionary["Wooden Plank"].count >= 1 || EGameFlow.gameMode != EGameFlow.GameMode.PLAYER)
        {
            GameObject plank = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Gadget gadget = Gadget.Dictionary["Wooden Plank"];

            plank.name = "Wooden Plank";
            plank.tag = "Gadget";

            // Set the transform of the plank
            if (rotation.y == 0)
            {
                plank.transform.position = new Vector3(pos.x + gadget.size.x / 2.0f, pos.y + gadget.size.y / 2.0f, pos.z + gadget.size.z / 2.0f);
                plank.transform.localScale = gadget.size;
            }
            else if (rotation.y == 90)
            {
                plank.transform.position = new Vector3(pos.x + gadget.size.z / 2.0f, pos.y + gadget.size.y / 2.0f, pos.z + gadget.size.x / 2.0f);
                plank.transform.localScale = gadget.size;
            }
            else if (rotation.y == 180)
            {
                plank.transform.position = new Vector3(pos.x + gadget.size.x / 2.0f, pos.y + gadget.size.y / 2.0f, 1 + pos.z - gadget.size.z / 2.0f);
                plank.transform.localScale = gadget.size;
            }
            else
            {
                plank.transform.position = new Vector3(1 + pos.x - gadget.size.z / 2.0f, pos.y + gadget.size.y / 2.0f, pos.z + gadget.size.x / 2.0f);
                plank.transform.localScale = gadget.size;
            }

            plank.transform.eulerAngles = new Vector3(0, rotation.y, 0);

            if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
            {
                // Remove the plank from the inventory
                Gadget.Dictionary["Wooden Plank"].count--;
            }
        }
    }
}
