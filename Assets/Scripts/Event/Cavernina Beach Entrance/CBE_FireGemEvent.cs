using UnityEngine;
using System.Collections;

public class CBE_FireGemEvent : MonoBehaviour 
{
    private enum EventPhase { START, COMBAT, END, FINISHED }
    private EventPhase eventPhase = EventPhase.START;

    World world;



    void Start()
    {
        SphereCollider boxCollider;
        boxCollider = gameObject.AddComponent<SphereCollider>();
        boxCollider.radius = 2;
        boxCollider.isTrigger = true;
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());
    }


    void Update()
    {
        switch (eventPhase)
        {
            case EventPhase.COMBAT:
                break;
            case EventPhase.END:
                {

                }
                break;
            default:
                break;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (eventPhase == EventPhase.START)
        {
            if (other.tag == "Player")
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    EventsLib.EraseVoxels(world, new IntVector3(51, 8, 29), new IntVector3(51, 14, 39));
                    EventsLib.EraseVoxels(world, new IntVector3(32, 8, 29), new IntVector3(32, 14, 39));
                    EventsLib.FillWithVoxels(world, "Fire Amethyst Smooth Rock", new IntVector3(40, 8, 44), new IntVector3(43, 14, 44));
                }
            }
        }
    }
}
