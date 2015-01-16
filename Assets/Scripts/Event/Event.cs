using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Event
{
    public static void Place(World world, Player player, string ID, Vector3 position, Vector3 colliderScale)
    {
        GameObject eventObj = new GameObject();

        eventObj.name = ID;
        eventObj.tag = "Event";

        eventObj.transform.position = position;

        eventObj.transform.parent = world.eventsController.transform;

        eventObj.AddComponent<EventComponent>();
        eventObj.GetComponent<EventComponent>().world = world;
        eventObj.GetComponent<EventComponent>().player = player;

        eventObj.AddComponent<BoxCollider>();
        eventObj.GetComponent<BoxCollider>().isTrigger = true;
        eventObj.GetComponent<BoxCollider>().size = colliderScale;
    }
}
