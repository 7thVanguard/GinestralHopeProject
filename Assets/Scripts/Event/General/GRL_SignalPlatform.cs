using UnityEngine;
using System.Collections;

public class GRL_SignalPlatform : MonoBehaviour 
{
    public Vector3 activePosition;
    public Vector3 nonActivePosition;

    public GameObject emitter;

    private float speed = 0;
    private bool emitting;


    void Update()
    {
        if (emitter.GetComponent<GRL_PressurePlate>() != null)
            emitting = emitter.GetComponent<GRL_PressurePlate>().emitting;

        if (emitting)
            transform.parent.position = GamePhysics.BoundedLerp(transform.parent.position, activePosition, ref speed, 0.1f, 0.1f);
        else
            transform.parent.position = GamePhysics.BoundedLerp(transform.parent.position, nonActivePosition, ref speed, 0.1f, 0.1f);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = transform;
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            other.transform.parent = null;
    }
}
