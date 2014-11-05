using UnityEngine;
using System.Collections;

public static class LVGadget
{
    public static void placePlank(Vector3 position, int rotation)
    {
        if (VoxelDictionary.GlobalVoxelsDictionary.ContainsKey("Wooden Plank"))
        {
            if (InventoryDictionary.GlobalVoxelInventory["Wooden Plank"].count >= 1)
            {
                GameObject plank = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Gadget gadget = (Gadget)VoxelDictionary.GlobalVoxelsDictionary["Wooden Plank"];

                plank.name = "Wooden Plank";
                plank.tag = "Gadget";

                // Set the transform of the plank
                if (rotation == 0)
                {
                    plank.transform.position = new Vector3(position.x + gadget.sizeX / 2.0f, position.y + gadget.sizeY / 2.0f, position.z + gadget.sizeZ / 2.0f);
                    plank.transform.localScale = new Vector3(gadget.sizeX, gadget.sizeY, gadget.sizeZ);
                }
                else if (rotation == 90)
                {
                    plank.transform.position = new Vector3(position.x + gadget.sizeZ / 2.0f, position.y + gadget.sizeY / 2.0f, position.z + gadget.sizeX / 2.0f);
                    plank.transform.localScale = new Vector3(gadget.sizeX, gadget.sizeY, gadget.sizeZ);
                }
                else if (rotation == 180)
                {
                    plank.transform.position = new Vector3(position.x + gadget.sizeX / 2.0f, position.y + gadget.sizeY / 2.0f, 1 + position.z - gadget.sizeZ / 2.0f);
                    plank.transform.localScale = new Vector3(gadget.sizeX, gadget.sizeY, gadget.sizeZ);
                }
                else
                {
                    plank.transform.position = new Vector3(1 + position.x - gadget.sizeZ / 2.0f, position.y + gadget.sizeY / 2.0f, position.z + gadget.sizeX / 2.0f);
                    plank.transform.localScale = new Vector3(gadget.sizeX, gadget.sizeY, gadget.sizeZ);
                }

                plank.transform.eulerAngles = new Vector3(0, rotation, 0);

                // Remove the plank from the inventory
                InventoryDictionary.GlobalVoxelInventory["Wooden Plank"].count--;
            }
        }
        InventoryDictionary.GlobalItemInventory["Wood Pieces"].count++;
        InventoryDictionary.GlobalItemInventory["Nails"].count += 4;
    }
}
