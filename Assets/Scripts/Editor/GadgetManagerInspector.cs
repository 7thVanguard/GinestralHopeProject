using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(GadgetDictionary))]
internal class GadgetManagerInspector : Editor 
{
    public override void OnInspectorGUI()
    {
        // We leave it empty so we will have a clean inspector
    }
}
