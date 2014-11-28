using UnityEngine;
using System.Collections;

public class FireTempleEntranceEvent : MonoBehaviour 
{
    World world;



	void Start () 
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
        if (other.tag == "Player")
        {
            EventsLib.EraseVoxels(world, new IntVector3(42, 19, 59), new IntVector3(41, 17, 59));
        }
    }
}
