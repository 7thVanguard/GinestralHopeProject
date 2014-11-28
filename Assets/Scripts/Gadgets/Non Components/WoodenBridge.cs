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
            Transform woodenBridge = Transform.Instantiate(world.gadgets.FindChild("Wooden Bridge 6m")) as Transform;
            Gadget gadget = Gadget.Dictionary["Wooden Bridge"];

            woodenBridge.name = "Wooden Bridge";
            woodenBridge.tag = "Gadget";
            woodenBridge.transform.parent = world.gadgetsController.transform;

            rotation.y += 90;
            pos += new Vector3(-0.5f, 0, -0.5f);


            // Set the transform of the plank
            if (rotation.y == 360)
                woodenBridge.transform.position = new Vector3(1 + pos.x - size.x / 2.0f, pos.y, pos.z + size.z / 2.0f);
            else if (rotation.y == 90)
                woodenBridge.transform.position = new Vector3(pos.x + size.z / 2.0f, pos.y, pos.z + size.x / 2.0f);
            else if (rotation.y == 180)
                woodenBridge.transform.position = new Vector3(pos.x + size.x / 2.0f, pos.y, pos.z + size.z / 2.0f);
            else
                woodenBridge.transform.position = new Vector3(pos.x + size.z / 2.0f, pos.y, 1 + pos.z - size.x / 2.0f);

            woodenBridge.transform.eulerAngles = new Vector3(0, rotation.y, 0);

            if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
            {
                // Remove the plank from the inventory
                Gadget.Dictionary["Wooden Bridge"].count--;
            }
        }
    }
}
