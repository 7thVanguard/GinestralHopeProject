using UnityEngine;
using System.Collections;

public class SignalPlatformBehaviour : MonoBehaviour 
{
    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public Vector3 endPosition;

    private float speed = 0;

    private bool onStay = false;



    void Start()
    {

    }


    void Update()
    {
        if (onStay)
            transform.position = GamePhysics.BoundedLerp(transform.position, endPosition, ref speed, 0.1f, 0.1f);
        else
            transform.position = GamePhysics.BoundedLerp(transform.position, initialPosition, ref speed, 0.1f, 0.1f);
    }
}
