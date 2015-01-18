﻿using UnityEngine;
using System.Collections;

public class GRL_YellowOrb : MonoBehaviour
{
    World world;
    GameObject greenOrb;

    private bool active;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        greenOrb = GameObject.Instantiate((GameObject)Resources.Load("Particle Systems/Ginestral Hope/Yellow Orb/Yellow Orb")) as GameObject;
        greenOrb.transform.parent = this.transform;
        greenOrb.transform.localPosition = Vector3.zero;
    }


    void Update()
    {
        if (active)
        {

        }
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                active = true;
            }
    }
}
