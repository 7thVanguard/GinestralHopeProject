using UnityEngine;
using System.Collections;

public class ContactPlatformBehaviour : MonoBehaviour 
{
    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public Vector3 endPosition;

    private float speed = 0;

    private bool onStay = false;



    void Update()
    {
        if (onStay)
            transform.position = GamePhysics.BoundedLerp(transform.position, endPosition, ref speed, 0.1f, 0.1f);
        else
            transform.position = GamePhysics.BoundedLerp(transform.position, initialPosition, ref speed, 0.1f, 0.1f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                onStay = true;
                Global.player.playerObj.transform.parent = transform;
                speed *= -1;
            }
    }


    void OnTriggerExit(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                onStay = false;
                Global.player.playerObj.transform.parent = null;
                speed *= -1;
            }
    }
}
