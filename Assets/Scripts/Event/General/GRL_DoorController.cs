using UnityEngine;
using System.Collections;

public class GRL_DoorController : MonoBehaviour 
{
    World world;

    public GameObject firstDoor;
    public GameObject secondDoor;
    public Vector3 firstDoorObjectivePosition;
    public Vector3 secondDoorObjectivePosition;

    public Color ambient;

    public bool activeOnEnter;

    private float timeCounter = 0;
    private bool active;

    private bool inTrigger = false;


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
        inTrigger = true;

        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                if (activeOnEnter)
                {
                    EventsLib.SetRenderambient(ambient);
                    EventsLib.SetDoorOpenDoubleSlider(firstDoor, firstDoorObjectivePosition, secondDoor, secondDoorObjectivePosition);

                    timeCounter = 10;
                    active = true;
                }
                else
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        EventsLib.SetRenderambient(ambient);
                        EventsLib.SetDoorOpenDoubleSlider(firstDoor, firstDoorObjectivePosition, secondDoor, secondDoorObjectivePosition);

                        timeCounter = 10;
                        active = true;
                    }
                }
            }
    }


    void OnTriggerExit()
    {
        inTrigger = false;
    }


    void OnGUI()
    {
        if (!activeOnEnter)
            if (inTrigger)
                EventsLib.DrawInteractivity();
    }
}
