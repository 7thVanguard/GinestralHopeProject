using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Structure
{
    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Interactive> Dictionary;

    // Variables
    public Vector3 size;
    public string ID;

    public virtual void Init(World world, Player player, MainCamera mainCamera, Interactive gadget)
    {

    }
}
