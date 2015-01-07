using UnityEngine;
using System.Collections;

public class CFT_Braziers : MonoBehaviour 
{
    World world;

    Transform door;
    Transform brazier1;
    Transform brazier2;
    Transform brazier3;
    Transform brazier4;

    private bool active = false;
    private bool opening = false;
    private bool finished = false;


    void Start()
    {
        BoxCollider boxCollider;
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(2, 6, 20);
        boxCollider.isTrigger = true;
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        // Detection of the objects in the event
        RaycastHit impact;

        if (Physics.Raycast(new Vector3(68.5f, 15.5f, 32), new Vector3(0, 0, -1), out impact, 5))
            door = impact.transform;

        if (Physics.Raycast(new Vector3(71, 19, 44.5f), new Vector3(1, 0, 0), out impact, 5))
            brazier1 = impact.transform;
        if (Physics.Raycast(new Vector3(61, 19, 44.5f), new Vector3(1, 0, 0), out impact, 5))
            brazier2 = impact.transform;
        if (Physics.Raycast(new Vector3(61, 19, 44.5f), new Vector3(1, 0, 0), out impact, 5))
            brazier3 = impact.transform;
        if (Physics.Raycast(new Vector3(71, 19, 44.5f), new Vector3(1, 0, 0), out impact, 5))
            brazier4 = impact.transform;
    }


    void Update()
    {
        if (active)
        {
            if (brazier1.GetComponent<BrazierBehaviour>().active &&
                brazier2.GetComponent<BrazierBehaviour>().active &&
                brazier3.GetComponent<BrazierBehaviour>().active &&
                brazier4.GetComponent<BrazierBehaviour>().active)
            {
                active = false;
                opening = true;
                finished = true;
            }
        }

        if (opening)
        {
            door.position = Vector3.Lerp(door.position, new Vector3(68.5f, 18.5f, 30), 0.001f);
            if (door.position.y > 18.45f)
                opening = false;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                if (!finished)
                    active = true;
            }
    }
}
