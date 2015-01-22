using UnityEngine;
using System.Collections;

public class ContactPlatformBehaviour : MonoBehaviour 
{
    public Vector3 initialPosition;
    public Vector3 endPosition;

    private bool onStay = false;



    void Update()
    {
        if (onStay)
        {
            if (Vector3.Distance(transform.position, endPosition) > 0.1f)
                transform.position += Vector3.Normalize(endPosition - initialPosition) * 0.1f;
        }
        else
            if (Vector3.Distance(transform.position, initialPosition) > 0.1f)
                transform.position += Vector3.Normalize(initialPosition - endPosition) * 0.1f;
    }


    void OnTriggerEnter(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                onStay = true;
                Global.player.playerObj.transform.parent = transform;
            }
    }


    void OnTriggerExit(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                onStay = false;
                Global.player.playerObj.transform.parent = null;
            }
    }
}
