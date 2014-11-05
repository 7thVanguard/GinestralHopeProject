using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(VoxelDictionary))]
internal class VoxelManagerInspector : Editor 
{
    public override void OnInspectorGUI()
    {
        // We leave it empty so we will have a clean inspector
    }
}
