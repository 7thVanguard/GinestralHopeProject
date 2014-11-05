using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(InventoryDictionary))]
internal class InventoryManagerInspector : Editor 
{
    public override void OnInspectorGUI()
    {
        // We leave it empty so we will have a clean inspector
    }
}
