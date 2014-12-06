﻿using UnityEngine;
using System.Collections;

public class IronPieces : Geometry 
{
    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;
        size = new Vector3(1, 1, 1);
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot)
    {
        Transform ironPieces = Object.Instantiate(world.gadgets.FindChild("Iron Pieces"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        ironPieces.name = "Iron Pieces";
        ironPieces.tag = "Geometry";
        ironPieces.transform.parent = world.gadgetsController.transform;
    }
}