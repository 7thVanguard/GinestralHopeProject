using UnityEngine;
using System.Collections;


[System.Serializable]
public class Voxel : ScriptableObject 
{
    public string ID;
    public int blastResistance;
    public bool transparent;

    public int count;
}
