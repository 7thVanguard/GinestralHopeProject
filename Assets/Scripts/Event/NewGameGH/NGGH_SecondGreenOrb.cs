﻿using UnityEngine;
using System.Collections;

public class NGGH_SecondGreenOrb : MonoBehaviour 
{
    World world;
    GameObject greenOrb;

    private bool active;
    private bool finished;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        greenOrb = GameObject.Instantiate((GameObject)Resources.Load("Particle Systems/Ginestral Hope/Green Orb/Green Orb")) as GameObject;
        greenOrb.transform.parent = this.transform;
        greenOrb.transform.localPosition = Vector3.zero;
    }


    void Update()
    {
        if (!finished)
            if (active)
            {
                GameObject.Destroy(greenOrb);
                finished = true;
            }
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                LevelUnlocks.lvlNewGameGHGreenOrb2 = true;
                active = true;
            }
    }
}
