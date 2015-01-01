using UnityEngine;
using System.Collections;

public class CBE_OnlySavePointEvent : MonoBehaviour 
{
    World world;
    Player player;



	void Start () 
    {
        BoxCollider boxCollider;
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(4, 4, 4);
        boxCollider.isTrigger = true;
        this.world = gameObject.GetComponent<EventComponent>().world;
        this.player = gameObject.GetComponent<EventComponent>().player;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());
	}


    void OnTriggerEnter(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
                    world.worldObj.GetComponent<GameManager>().gameSerializer.Save(world, player, "CaverninaOnPlaySave");
    }
}
