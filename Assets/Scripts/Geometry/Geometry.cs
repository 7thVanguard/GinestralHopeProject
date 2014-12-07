using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Geometry
{
    public enum PlacedOn { FLOOR, WALL, AIR }

    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Geometry> Dictionary;

    // Variables
    public PlacedOn placedOn;


    public virtual void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        Dictionary = new Dictionary<string, Geometry>();

        //+ Geometry
        Geometry geometry;

        // Wooden Bridge 6m
        geometry = new WoodenBridge();
        geometry.Init(world, player, mainCamera);
        Dictionary.Add("Wooden Bridge 6m", geometry);

        // Torch
        geometry = new Torch();
        geometry.Init(world, player, mainCamera);
        Dictionary.Add("Torch", geometry);

        // Altar
        geometry = new Altar();
        geometry.Init(world, player, mainCamera);
        Dictionary.Add("Altar", geometry);

        // Fire Gem
        geometry = new FireGem();
        geometry.Init(world, player, mainCamera);
        Dictionary.Add("Fire Gem", geometry);

        // Chest
        geometry = new Chest();
        geometry.Init(world, player, mainCamera);
        Dictionary.Add("Chest", geometry);

        // Wood Pieces
        geometry = new WoodPieces();
        geometry.Init(world, player, mainCamera);
        Dictionary.Add("Wood Pieces", geometry);

        // Iron Pieces
        geometry = new IronPieces();
        geometry.Init(world, player, mainCamera);
        Dictionary.Add("Iron Pieces", geometry);

        geometry = Dictionary["Wooden Bridge 6m"];
    }


    public virtual void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {

    }
}
