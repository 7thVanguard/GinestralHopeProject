using UnityEngine;
using System.Collections;

public class SignalPlatformBehaviour : MonoBehaviour 
{
    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public Vector3 endPosition;

    [HideInInspector] public bool onSignal = false;

    private float speed = 0;


    void Update()
    {
        if (onSignal)
            transform.position = GamePhysics.BoundedLerp(transform.position, endPosition, ref speed, 0.1f, 0.1f);
        else
            transform.position = GamePhysics.BoundedLerp(transform.position, initialPosition, ref speed, 0.1f, 0.1f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                Global.player.playerObj.transform.parent = transform;
    }


    void OnTriggerExit(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                Global.player.playerObj.transform.parent = null;
    }
}
