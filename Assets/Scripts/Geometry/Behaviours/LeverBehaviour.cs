using UnityEngine;
using System.Collections;

public class LeverBehaviour : MonoBehaviour 
{
    public bool locked = false;
    public bool emiting = false;


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                if (Input.GetKeyUp(KeyCode.E))
                    emiting = !emiting;
    }
}
