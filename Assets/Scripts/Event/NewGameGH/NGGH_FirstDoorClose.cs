﻿using UnityEngine;
using System.Collections;

public class NGGH_FirstDoorClose : MonoBehaviour 
{
    World world;

    private GameObject firstDoor;
    private GameObject secondDoor;
    private Vector3 firstDoorObjectivePosition;
    private Vector3 secondDoorObjectivePosition;

    private Color ambient = new Color(74 / 255f, 79 / 255f, 57 / 255f, 1);

    private float timeCounter = 0;
    private bool active;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        RaycastHit impact;

        if (Physics.Raycast(new Vector3(4.5f, 2.5f, 18f), new Vector3(0, 0, 1), out impact, 5))
            firstDoor = impact.transform.gameObject;
        if (Physics.Raycast(new Vector3(6.5f, 2.5f, 18f), new Vector3(0, 0, 1), out impact, 5))
            secondDoor = impact.transform.gameObject;

        firstDoorObjectivePosition = new Vector3(5.5f, 0.5f, 20.5f);
        secondDoorObjectivePosition = new Vector3(5.5f, 0.5f, 20.5f);
    }


    void Update()
    {
        if (active)
        {
            EventsLib.UpdateRenderambient();
            EventsLib.UpdateDoorOpenDoubleSlider();

            timeCounter -= Time.deltaTime;
            if (timeCounter < 0)
                active = false;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                EventsLib.SetRenderambient(ambient);
                EventsLib.SetDoorOpenDoubleSlider(firstDoor, firstDoorObjectivePosition, secondDoor, secondDoorObjectivePosition);

                timeCounter = 10;
                active = true;
            }
    }
}