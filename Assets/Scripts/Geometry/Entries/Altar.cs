﻿using UnityEngine;
using System.Collections;

public class Altar : Geometry 
{
    GameObject altar;



    public override void Init(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;

        placedOn = PlacedOn.FLOOR;

        altar = (GameObject)Resources.Load("Props/Geometry/Altar/Altar");
    }


    public override void Place(string ID, Vector3 pos, Vector3 rot, Vector3 scale, bool firstPlacing)
    {
        altar = GameObject.Instantiate(altar, pos, Quaternion.Euler(rot)) as GameObject;

        // Head atributes
        altar.name = "Altar";
        altar.tag = "Geometry";

        altar.transform.localScale = scale;
        altar.transform.parent = world.geometryController.transform;
    }
}
