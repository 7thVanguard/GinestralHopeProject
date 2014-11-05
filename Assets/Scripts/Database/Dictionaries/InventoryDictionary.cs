using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryDictionary : MonoBehaviour 
{
    public static Dictionary<string, Item> GlobalItemInventory = new Dictionary<string, Item>();
    public static Dictionary<string, Voxel> GlobalVoxelInventory = new Dictionary<string, Voxel>();

    // Items
    Weapon weapon;
    Armor armor;
    Consumable consumable;
    GameComponent gameComponent;

    // Voxels
    Gadget gadget;
    

    void Start()
    {
        // Initializes the inventory with the items information
        GlobalItemInventory = ItemDictionary.GlobalItemsDictionary;
        GlobalVoxelInventory = VoxelDictionary.GlobalVoxelsDictionary;
    }

    void OnGUI()
    {
        // Show woodpieces
        gameComponent = (GameComponent)GlobalItemInventory["Wood Pieces"];
        GUI.Label(new Rect(Screen.width * 0.8f, Screen.height * 0.75f, 200, 50), gameComponent.name + "  " + gameComponent.count);

        // Show wooden planks
        gadget = (Gadget)GlobalVoxelInventory["Wooden Plank"];
        GUI.Label(new Rect(Screen.width * 0.8f, Screen.height * 0.80f, 200, 50), gadget.name + "  " + gadget.count);
    }
}
