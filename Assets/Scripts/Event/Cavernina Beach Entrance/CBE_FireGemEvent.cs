using UnityEngine;
using System.Collections;

public class CBE_FireGemEvent : MonoBehaviour 
{
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


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                EventsLib.EraseVoxels(world, new IntVector3(51, 8, 29), new IntVector3(51, 14, 39));
                EventsLib.EraseVoxels(world, new IntVector3(32, 8, 29), new IntVector3(32, 14, 39));
            }
        }
    }
}
