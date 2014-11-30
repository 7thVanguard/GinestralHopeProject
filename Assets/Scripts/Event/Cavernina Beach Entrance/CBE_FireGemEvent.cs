using UnityEngine;
using System.Collections;

public class CBE_FireGemEvent : MonoBehaviour 
{
    private enum EventPhase { START, COMBAT, END, FINISHED }
    private EventPhase eventPhase = EventPhase.START;

    World world;


    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;
    private GameObject enemy4;

    private bool combatStart = false;



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
                {
                    if (!combatStart)
                    {
                        enemy1 = Enemy.Dictionary["Normal Slime"].Place(new Vector3(54, 11.5f, 37));
                        enemy2 = Enemy.Dictionary["Normal Slime"].Place(new Vector3(54, 11.5f, 31));
                        enemy3 = Enemy.Dictionary["Normal Slime"].Place(new Vector3(29, 11.5f, 37));
                        enemy4 = Enemy.Dictionary["Normal Slime"].Place(new Vector3(29, 11.5f, 31));
                        combatStart = true;
                    }


                    if (enemy1 == null && enemy2 == null && enemy3 == null && enemy4 == null)
                        eventPhase = EventPhase.END;
                }
                break;
            case EventPhase.END:
                {
                    EventsLib.EraseVoxels(world, new IntVector3(40, 8, 44), new IntVector3(43, 14, 44));
                    eventPhase = EventPhase.FINISHED;
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
                    eventPhase = EventPhase.COMBAT;
                }
            }
        }
    }
}
