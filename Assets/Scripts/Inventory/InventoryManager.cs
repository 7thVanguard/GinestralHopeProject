using UnityEngine;
using System.Collections;


public struct InventoryItem
{
    public string name;
    public string type;
}


public static class InventoryManager
{
    public static InventoryItem[] inventory;
    public static int selectedSlot = 0;



    public static void Init()
    {
        inventory = new InventoryItem[10];

        for (int i = 0; i < inventory.Length; i++)
        {
            inventory[i].name = "none";
            inventory[i].type = "none";
        }
    }
}
