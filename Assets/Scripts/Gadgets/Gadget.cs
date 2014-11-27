﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Gadget
{
    protected World world;
    protected Player player;
    protected MainCamera mainCamera;

    public static Dictionary<string, Gadget> Dictionary;

    // Variables
    public string ID;

    public Vector3 size;
    public int count;

    public bool placedOnFloor;

    // Drops
    public bool givesComponents;
    public int dropCount;

    public virtual void Init(World world, Player player, MainCamera mainCamera, Gadget gadget)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        Dictionary = new Dictionary<string, Gadget>();

        //+ Non components
        // Wooden Plank
        gadget = new WoodenBridge();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Wooden Bridge", gadget);

        // Torch
        gadget = new Torch();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Torch", gadget);

        // Bomb
        gadget = new Bomb();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Bomb", gadget);

        // Altar
        gadget = new Altar();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Altar", gadget);

        // Fire Gem
        gadget = new FireGem();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Fire Gem", gadget);

        // Fire Gem
        gadget = new Chest();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Chest", gadget);


        //+ Components
        // Wood Pieces
        gadget = new WoodPieces();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Wood Pieces", gadget);

        // Iron Pieces
        gadget = new IronPieces();
        gadget.Init(world, player, mainCamera, gadget);
        Dictionary.Add("Iron Pieces", gadget);

        gadget = Dictionary["Wooden Bridge"];
    }


    public virtual void Place(string ID, Vector3 pos, Vector3 rotation)
    {

    }
}
