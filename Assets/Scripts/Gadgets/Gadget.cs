using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Gadget
{
    public enum PlacedOn { FLOOR, WALL, AIR }

    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Gadget> Dictionary;

    // Variables
    public PlacedOn placedOn;
    public Vector3 size;
    public string ID;
    public bool isCompressed;

    

    public virtual void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        Dictionary = new Dictionary<string, Gadget>();

        //+ Gadgets
        // Wooden Plank
        gadget = new WoodenPlank();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Wooden Plank", gadget);

        gadget = Dictionary["Wooden Plank"];
    }


    public virtual void Place(string ID, Vector3 pos, Vector3 rotation)
    {

    }


    public virtual void Compress()
    {

    }


    public virtual void DeCompress()
    {

    }


    public virtual void Aim()
    {

    }
}
