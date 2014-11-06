using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDictionary : MonoBehaviour
{
    public static Dictionary<string, Item> GlobalItemsDictionary = new Dictionary<string, Item>();
    public List<Item> ItemsList = new List<Item>();

    void Awake()
    {
        foreach (Item item in ItemsList)
            GlobalItemsDictionary.Add(item.name, item);
    }
}
