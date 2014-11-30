using UnityEngine;
using System.Collections;

public static class SInventory
{
    public static void CraftWoodenBridge()
    {
        if (Gadget.Dictionary["Wood Pieces"].count >= 6)
        {
            Gadget.Dictionary["Wood Pieces"].count -= 6;
            Gadget.Dictionary["Wooden Bridge"].count++;
        }
    }


    public static void CraftWoodPlank()
    {
        if (Gadget.Dictionary["Iron Pieces"].count >= 5)
        {
            Gadget.Dictionary["Iron Pieces"].count -= 5;
            Gadget.Dictionary["Bomb"].count++;
        }
    }
}
