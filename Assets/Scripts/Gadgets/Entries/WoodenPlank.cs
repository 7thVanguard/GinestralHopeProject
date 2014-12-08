using UnityEngine;
using System.Collections;

public class WoodenPlank : Gadget 
{
    // This pivots will control where will be placed the box when compressed
    Vector3 firstPivotPosition;
    Vector3 secondPivotPosition;



    public override void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
        isCompressed = false;
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, bool firstPlacing)
    {
        if (firstPlacing)
        {
            rot.y += 90;
            if (rot.y == 90)
                pos.z += 2.5f;
            else if (rot.y == 180)
                pos.x += 2.5f;
            else if (rot.y == 270)
                pos.z -= 2.5f;
            else
                pos.x -= 2.5f;
        }

        Transform woodenPlank = Transform.Instantiate(world.gadgets.FindChild("Wooden Plank Compressed"), pos, Quaternion.Euler(rot)) as Transform;

        woodenPlank.name = "Wooden Plank";
        woodenPlank.tag = "Gadget";

        if (isCompressed)
            woodenPlank.transform.localScale = Vector3.one;
        else
            woodenPlank.transform.localScale = new Vector3(6, 0.1f, 1);

        woodenPlank.transform.parent = world.gadgetsController.transform;

        if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
            EGameFlow.selectedGadget = "none";
    }
}
