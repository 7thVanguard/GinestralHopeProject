using UnityEngine;
using System.Collections;

public static class SInventory
{
    public static void CraftWoodPlank()
    {
        if (GameComponentDictionary.GameComponentsDictionary["Wood Pieces"].count >= 5 &&
            GameComponentDictionary.GameComponentsDictionary["Nails"].count >= 20)
        {
            GameComponentDictionary.GameComponentsDictionary["Wood Pieces"].count -= 5;
            GameComponentDictionary.GameComponentsDictionary["Nails"].count -= 20;
            GadgetDictionary.GadgetsDictionary["Wooden Plank"].count++;
        }
    }
}
