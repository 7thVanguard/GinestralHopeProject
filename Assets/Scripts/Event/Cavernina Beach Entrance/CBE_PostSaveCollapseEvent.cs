using UnityEngine;
using System.Collections;

public class CBE_PostSaveCollapseEvent : MonoBehaviour 
{
    World world;



    void Start()
    {
        BoxCollider boxCollider;
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(4, 4, 4);
        boxCollider.isTrigger = true;
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());
    }


    void OnTriggerEnter(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                EventsLib.FillWithVoxels(world, "Large Rock", new IntVector3(60, 15, 110), new IntVector3(59, 19, 110));
    }
}
