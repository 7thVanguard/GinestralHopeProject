using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class VoxelDictionary : MonoBehaviour 
{
    public static Dictionary<string, Voxel> GlobalVoxelsDictionary = new Dictionary<string, Voxel>();
    public List<Voxel> VoxelsList = new List<Voxel>();

    void Start()
    {
        foreach (Voxel voxel in VoxelsList)
            GlobalVoxelsDictionary.Add(voxel.name, voxel);
    }
}
