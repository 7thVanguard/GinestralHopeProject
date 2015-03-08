using UnityEngine;
using System.Collections;

public class GRL_SignalPlatform : MonoBehaviour 
{
    public Vector3 activePosition;
    public Vector3 nonActivePosition;

    public GameObject emitter;

    private bool emitting;


    void Update()
    {
        if (emitter.GetComponent<GRL_PressurePlate>() != null)
            emitting = emitter.GetComponent<GRL_PressurePlate>().emitting;

        if (emitting)
            transform.parent.position = Vector3.Lerp(transform.parent.position, activePosition, 0.05f);
        else
            transform.parent.position = Vector3.Lerp(transform.parent.position, nonActivePosition, 0.05f);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = transform.parent;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
