﻿using UnityEngine;
using System.Collections;

public class Altar : Geometry 
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
        Transform altar = Object.Instantiate(world.gadgets.FindChild("Altar"), pos, Quaternion.Euler(rot)) as Transform;

        // Head atributes
        altar.name = "Altar";
        altar.tag = "Geometry";
        altar.transform.parent = world.gadgetsController.transform;
    }
}