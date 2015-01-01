using UnityEngine;
using System.Collections;

public static class InventoryLib
{
    public static bool AddToInventory(string name, string type)
    {
        for (int i = 0; i < InventoryManager.inventory.Length; i++)
            if (InventoryManager.inventory[i].name == "none")
            {
                InventoryManager.inventory[i].name = name;
                InventoryManager.inventory[i].type = type;
                return true;
            }

            return false;
    }
}
