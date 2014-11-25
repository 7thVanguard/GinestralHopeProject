using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Event
{
    public static void Place(string ID, EventComponent.EventType eventType, Vector3 position)
    {
        GameObject eventObj = new GameObject();
        eventObj.name = ID;
        eventObj.tag = "Event";
        eventObj.transform.position = position;
        eventObj.AddComponent<EventComponent>();
        eventObj.GetComponent<EventComponent>().eventType = eventType;
    }
}
