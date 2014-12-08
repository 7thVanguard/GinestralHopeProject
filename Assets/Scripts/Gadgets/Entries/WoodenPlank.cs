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

        Transform woodenPlank = Transform.Instantiate(world.gadgets.FindChild("Wooden Plank"), pos, Quaternion.Euler(rot)) as Transform;

        woodenPlank.name = "Wooden Plank";
        woodenPlank.tag = "Gadget";

        woodenPlank.transform.parent = world.gadgetsController.transform;

        if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
            EGameFlow.selectedGadget = "none";
    }


    public override void ChangeCompression(World world, Player player, MainCamera mainCamera)
    {
        Transform woodenPlank = mainCamera.raycast.transform;
        Vector3 pos;
        Vector3 rot;

        if (woodenPlank.name == "Wooden Plank")
        {
            // Check where should we compress the bridge
            if (Mathf.Round(woodenPlank.transform.eulerAngles.y) == 90 || Mathf.Round(woodenPlank.transform.eulerAngles.y) == 270)
            {
                if (Vector3.Distance(player.playerObj.transform.position, woodenPlank.position + new Vector3(0, 0, 2.5f)) <
                    Vector3.Distance(player.playerObj.transform.position, woodenPlank.position - new Vector3(0, 0, 2.5f)))
                {
                    pos = woodenPlank.position + new Vector3(0, 0, 2.5f);
                }
                else
                {
                    pos = woodenPlank.position - new Vector3(0, 0, 2.5f);
                }
            }
            else
            {
                if (Vector3.Distance(player.playerObj.transform.position, woodenPlank.position + new Vector3(2.5f, 0, 0)) <
                    Vector3.Distance(player.playerObj.transform.position, woodenPlank.position - new Vector3(2.5f, 0, 0)))
                {
                    pos = woodenPlank.position + new Vector3(2.5f, 0, 0);
                }
                else
                {
                    pos = woodenPlank.position - new Vector3(2.5f, 0, 0);
                }
            }

            // Set the rotation the same as the bridge
            rot = woodenPlank.eulerAngles;

            // Destroy the uncompressed bridge
            Object.Destroy(mainCamera.raycast.transform.gameObject);

            // Create the compressed bridge
            Transform newWoodenPlank = Transform.Instantiate(world.gadgets.FindChild("Wooden Plank Compressed"), pos, Quaternion.Euler(rot)) as Transform;

            newWoodenPlank.name = "Wooden Plank Compressed";
            newWoodenPlank.tag = "Gadget";
            newWoodenPlank.transform.parent = world.gadgetsController.transform;
        }
        else
        {
            
        }
    }
}
