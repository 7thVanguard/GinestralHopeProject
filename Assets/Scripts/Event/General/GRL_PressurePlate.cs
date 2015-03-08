using UnityEngine;
using System.Collections;

public class GRL_PressurePlate : MonoBehaviour 
{
    private const float nonPressedHeight = -0.05f;
    private const float pressedHeight = -0.15f;

    public bool emitting;


    void Update()
    {
        if (emitting)
            transform.parent.localPosition = new Vector3(0, Mathf.Lerp(transform.parent.localPosition.y, pressedHeight, 0.1f), 0);
        else
            transform.parent.localPosition = new Vector3(0, Mathf.Lerp(transform.parent.localPosition.y, nonPressedHeight, 0.1f), 0);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.transform.GetComponent<CharacterController>().isGrounded)
            {
                other.transform.parent = transform.parent;
                emitting = true;
            }
            else
            {
                other.transform.parent = null;
                emitting = false;
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
            emitting = false;
        }
    }
}
