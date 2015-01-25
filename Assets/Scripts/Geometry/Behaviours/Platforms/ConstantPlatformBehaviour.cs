using UnityEngine;
using System.Collections;

public class ConstantPlatformBehaviour : MonoBehaviour 
{
    [HideInInspector] public Vector3 initialPosition;
    [HideInInspector] public Vector3 endPosition;

    private float speed = 0;

    private bool direction = false;



    void Update()
    {
        if (direction)
        {
            transform.position = GamePhysics.BoundedLerp(transform.position, endPosition, ref speed, 0.1f, 0.1f);
            if (Vector3.Distance(transform.position, endPosition) < 0.1f)
                direction = false;
        }
        else
        {
            transform.position = GamePhysics.BoundedLerp(transform.position, initialPosition, ref speed, 0.1f, 0.1f);
            if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
                direction = true;
        }
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
