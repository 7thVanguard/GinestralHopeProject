using UnityEngine;
using System.Collections;

public class WoodenPlank : Gadget 
{
    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
        isCompressed = true;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rotation)
    {
        if (EGameFlow.selectedGadget == "Wooden Plank" || EGameFlow.gameMode != EGameFlow.GameMode.PLAYER)
        {
            Transform woodenPlank = Transform.Instantiate(world.gadgets.FindChild("Wooden Plank Compressed")) as Transform;

            woodenPlank.name = "Wooden Plank";
            woodenPlank.tag = "Gadget";
            woodenPlank.transform.parent = world.gadgetsController.transform;

            woodenPlank.position = pos;

            if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
                EGameFlow.selectedGadget = "none";
        }
    }
}
