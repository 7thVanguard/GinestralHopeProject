using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item : ScriptableObject
{
    public string name = "";
    public string description = "";
    public int cost = 0;
    public int count = 0;
}
