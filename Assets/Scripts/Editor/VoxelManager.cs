using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class VoxelManager : EditorWindow
{
    //bool showingGadgets = false;


    //[MenuItem("Ginestral Hope/Voxel Database")]
    //static void Init()
    //{
    //    VoxelManager window = (VoxelManager)EditorWindow.CreateInstance(typeof(VoxelManager));
    //    window.Show();
    //}


    //void OnGUI()
    //{
    //    VoxelDictionary voxelsList = GameObject.Find("World").GetComponent<VoxelDictionary>();

    //    List<Gadget> GadgetList = new List<Gadget>();

    //    foreach (Voxel voxel in voxelsList.VoxelsList)
    //    {
    //        if (voxel.GetType() == typeof(Gadget))
    //            GadgetList.Add((Gadget)voxel);
    //    }

    //    // Write labels in the inspector
    //    EditorGUILayout.BeginHorizontal();

    //    //+ Gadget

    //    EditorGUILayout.BeginVertical();
    //    EditorGUI.indentLevel = 0;
    //    showingGadgets = EditorGUILayout.Foldout(showingGadgets, "Gadget");
    //    if (showingGadgets)
    //    {
    //        // Display the weapons in the database
    //        foreach (Gadget gadget in GadgetList)
    //        {
    //            EditorGUI.indentLevel = 2;

    //            // Set in horizontal the title name and the erase button
    //            EditorGUILayout.BeginHorizontal();
    //            EditorGUILayout.LabelField(gadget.name);
    //            if (GUILayout.Button("Erase gadget"))
    //                voxelsList.VoxelsList.Remove(gadget);
    //            EditorGUILayout.EndHorizontal();

    //            // Set the atributes
    //            EditorGUI.indentLevel = 3;
    //            gadget.name = EditorGUILayout.TextField("Name: ", gadget.name);
    //            gadget.blastResistance = int.Parse(EditorGUILayout.TextField("Blast Resistance: ", gadget.blastResistance.ToString()));
    //            gadget.transparent = bool.Parse(EditorGUILayout.TextField("Transparent: ", gadget.transparent.ToString()));

    //            // Display size horizontally
    //            EditorGUILayout.BeginHorizontal();
    //            gadget.sizeX = float.Parse(EditorGUILayout.TextField("Size X: ", gadget.sizeX.ToString()));
    //            gadget.sizeY = float.Parse(EditorGUILayout.TextField("Size Y: ", gadget.sizeY.ToString()));
    //            gadget.sizeZ = float.Parse(EditorGUILayout.TextField("Size Z: ", gadget.sizeZ.ToString()));
    //            EditorGUILayout.EndHorizontal();

    //            // Display drops
    //            EditorGUILayout.BeginHorizontal();
    //            gadget.voxelDrop = EditorGUILayout.TextField("Voxel drop: ", gadget.voxelDrop);
    //            gadget.voxelDropCount = int.Parse(EditorGUILayout.TextField("Count: ", gadget.voxelDropCount.ToString()));
    //            EditorGUILayout.EndHorizontal();
    //            EditorGUILayout.BeginHorizontal();
    //            gadget.componentDrop = EditorGUILayout.TextField("Component drop: ", gadget.componentDrop);
    //            gadget.componentDropCount = int.Parse(EditorGUILayout.TextField("Count: ", gadget.componentDropCount.ToString()));
    //            EditorGUILayout.EndHorizontal();
                

    //            EditorGUILayout.Space();
    //        }

    //        // Adding an item to the list
    //        if (GUILayout.Button("Add new gadget"))
    //        {
    //            Gadget gadget = (Gadget)ScriptableObject.CreateInstance<Gadget>();

    //            gadget.name = "New gadget";
    //            gadget.blastResistance = 0;
    //            gadget.transparent = false;

    //            gadget.sizeX = 1;
    //            gadget.sizeY = 1;
    //            gadget.sizeZ = 1;

    //            gadget.voxelDrop = "Nothing";
    //            gadget.voxelDropCount = 0;
    //            gadget.componentDrop = "Nothing";
    //            gadget.componentDropCount = 0;

    //            voxelsList.VoxelsList.Add(gadget);
    //        }
    //    }
    //    EditorGUILayout.EndVertical();

    //    EditorGUILayout.EndHorizontal();
    //}
}
