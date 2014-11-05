using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class InventoryManager : EditorWindow
{
    // Creates the new Window
    [MenuItem("Ginestral Hope/Inventory")]
    static void Init()
    {
        InventoryManager window = (InventoryManager)EditorWindow.CreateInstance(typeof(InventoryManager));
        window.Show();
    }

    
    void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();

        //+ Items

        foreach (KeyValuePair<string, Item> entry in InventoryDictionary.GlobalItemInventory)
            EditorGUILayout.LabelField("Name: " + entry.Value.name + "  " + entry.Value.count);

        if (GUILayout.Button("Craft"))
            SInventory.CraftWoodPlank();

        if (GUILayout.Button("Refresh Inventory")) { }

        EditorGUILayout.EndHorizontal();

        //+ Voxels

        EditorGUILayout.BeginHorizontal();

        foreach (KeyValuePair<string, Voxel> entry in InventoryDictionary.GlobalVoxelInventory)
            EditorGUILayout.LabelField("Name: " + entry.Value.name + "  " + entry.Value.count);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
    }
}
