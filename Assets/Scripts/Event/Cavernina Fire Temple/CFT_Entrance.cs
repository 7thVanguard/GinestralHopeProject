using UnityEngine;
using System.Collections;

public class CFT_Entrance : MonoBehaviour 
{
    World world;

    Transform leftDoor;
    Transform rightDoor;


    void Start()
    {
        BoxCollider boxCollider;
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(10, 6, 10);
        boxCollider.isTrigger = true;
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        // Detection of the objects in the event
        RaycastHit impact;

        if (Physics.Raycast(new Vector3(20, 17, 52), new Vector3(1, 0, 0), out impact, 5))
                leftDoor = impact.transform;

        if (Physics.Raycast(new Vector3(20, 17, 47), new Vector3(1, 0, 0), out impact, 5))
            rightDoor = impact.transform;
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                leftDoor.position = Vector3.Lerp(leftDoor.position, new Vector3(21.5f, 17, 62), 0.01f);
                rightDoor.position = Vector3.Lerp(rightDoor.position, new Vector3(21.5f, 17, 37), 0.01f);
            }
    }
}
