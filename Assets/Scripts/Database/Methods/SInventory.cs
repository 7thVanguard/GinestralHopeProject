using UnityEngine;
using System.Collections;

public static class SInventory
{
    public static void CraftWoodPlank()
    {
        if (GameComponentDictionary.GameComponentsDictionary["Wood Pieces"].count >= 6)
        {
            GameComponentDictionary.GameComponentsDictionary["Wood Pieces"].count -= 6;
            Gadget.Dictionary["Wooden Bridge"].count++;
        }
    }
}
