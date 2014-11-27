using UnityEngine;
using System.Collections;

public class WoodenBridge : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        ID = "Wooden Bridge";

        size = new Vector3(6, 0.1f, 1);
        count = 0;

        placedOnFloor = true;

        givesComponents = false;
        dropCount = 1;
    }

     

    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        if (Gadget.Dictionary["Wooden Bridge"].count >= 1 || EGameFlow.gameMode != EGameFlow.GameMode.PLAYER)
        {
            Transform plank = Transform.Instantiate(world.gadgets.FindChild("Wooden Bridge 6m")) as Transform;
            Gadget gadget = Gadget.Dictionary["Wooden Bridge"];

            plank.name = "Wooden Bridge";
            plank.tag = "Gadget";

            rotation.y += 90;
            pos += new Vector3(-0.5f, 0, -0.5f);


            // Set the transform of the plank
            if (rotation.y == 360)
                plank.transform.position = new Vector3(1 + pos.x - size.x / 2.0f, pos.y, pos.z + size.z / 2.0f);
            else if (rotation.y == 90)
                plank.transform.position = new Vector3(pos.x + size.z / 2.0f, pos.y, pos.z + size.x / 2.0f);
            else if (rotation.y == 180)
                plank.transform.position = new Vector3(pos.x + size.x / 2.0f, pos.y, pos.z + size.z / 2.0f);
            else
                plank.transform.position = new Vector3(pos.x + size.z / 2.0f, pos.y, 1 + pos.z - size.x / 2.0f);

            plank.transform.eulerAngles = new Vector3(0, rotation.y, 0);

            if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
            {
                // Remove the plank from the inventory
                Gadget.Dictionary["Wooden Bridge"].count--;
            }
        }
    }
}
