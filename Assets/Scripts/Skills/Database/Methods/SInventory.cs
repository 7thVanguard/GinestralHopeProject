using UnityEngine;
using System.Collections;

public static class SInventory
{
    public static void CraftWoodPlank()
    {
        if (InventoryDictionary.GlobalItemInventory["Wood Pieces"].count >= 5 &&
            InventoryDictionary.GlobalItemInventory["Nails"].count >= 20)
        {
            InventoryDictionary.GlobalItemInventory["Wood Pieces"].count -= 5;
            InventoryDictionary.GlobalItemInventory["Nails"].count -= 20;
            InventoryDictionary.GlobalVoxelInventory["Wooden Plank"].count++;
        }
    }
}
