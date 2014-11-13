using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item : ScriptableObject
{
    public string ID = "";
    public string description = "";
    public int cost = 0;
    public int count = 0;
}
