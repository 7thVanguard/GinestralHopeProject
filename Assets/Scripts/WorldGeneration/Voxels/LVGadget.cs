using UnityEngine;
using System.Collections;
using UnityEditor;


public static class LVGadget
{
    public static void placePlank(Vector3 position, int rotation)
    {
        if (Gadget.Dictionary.ContainsKey("Wooden Plank"))
        {
            if (Gadget.Dictionary["Wooden Plank"].count >= 1 || EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
            {
                GameObject plank = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Gadget gadget = Gadget.Dictionary["Wooden Plank"];

                plank.name = "Wooden Plank";
                plank.tag = "Gadget";

                // Set the transform of the plank
                if (rotation == 0)
                {
                    plank.transform.position = new Vector3(position.x + gadget.size.x / 2.0f, position.y + gadget.size.y / 2.0f, position.z + gadget.size.z / 2.0f);
                    plank.transform.localScale = gadget.size;
                }
                else if (rotation == 90)
                {
                    plank.transform.position = new Vector3(position.x + gadget.size.z / 2.0f, position.y + gadget.size.y / 2.0f, position.z + gadget.size.x / 2.0f);
                    plank.transform.localScale = gadget.size;
                }
                else if (rotation == 180)
                {
                    plank.transform.position = new Vector3(position.x + gadget.size.x / 2.0f, position.y + gadget.size.y / 2.0f, 1 + position.z - gadget.size.z / 2.0f);
                    plank.transform.localScale = gadget.size;
                }
                else
                {
                    plank.transform.position = new Vector3(1 + position.x - gadget.size.z / 2.0f, position.y + gadget.size.y / 2.0f, position.z + gadget.size.x / 2.0f);
                    plank.transform.localScale = gadget.size;
                }

                plank.transform.eulerAngles = new Vector3(0, rotation, 0);

                if (EGameFlow.generalMode == EGameFlow.GeneralMode.PLAYER)
                {
                    // Remove the plank from the inventory
                    Gadget.Dictionary["Wooden Plank"].count--;
                }
            }
        }
    }


    public static void placeWoodPiecesGadget(World world, Vector3 position)
    {
        if (EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
        {
            Transform woodPieces = world.woodPieces;

            woodPieces = Object.Instantiate(woodPieces, position, Quaternion.identity) as Transform;
            woodPieces.name = "Wood Pieces";
        }
    }


    public static void placeNailsGadget(World world, Vector3 position)
    {
        if (EGameFlow.generalMode == EGameFlow.GeneralMode.DEVELOPER)
        {
            Transform nails = world.nails;

            nails = Object.Instantiate(nails, position, Quaternion.identity) as Transform;
            nails.name = "Nails";
        }
    }
}
