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

        //+ GameComponents

        foreach (KeyValuePair<string, GameComponent> entry in GameComponentDictionary.GameComponentsDictionary)
            EditorGUILayout.LabelField("Name: " + entry.Value.nameKey + "  " + entry.Value.count);

        if (GUILayout.Button("Craft"))
            SInventory.CraftWoodPlank();

        if (GUILayout.Button("Refresh Inventory")) { }

        EditorGUILayout.EndHorizontal();

        //+ Gadgets

        EditorGUILayout.BeginHorizontal();

        foreach (KeyValuePair<string, Gadget> entry in Gadget.Dictionary)
            EditorGUILayout.LabelField("Name: " + entry.Value.ID + "  " + entry.Value.count);

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
    }
}
