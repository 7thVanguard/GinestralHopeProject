using UnityEngine;
using System.Collections;

public class CBE_OnlySavePointEvent : MonoBehaviour 
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
            if (EGameFlow.gameMode == EGameFlow.GameMode.PLAYER)
                world.worldObj.GetComponent<GameManager>().gameSerializer.Save(world, "CaverninaOnPlaySave");
        }
    }
}
