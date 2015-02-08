using UnityEngine;
using System.Collections;

public class LeverBehaviour : MonoBehaviour 
{
    public bool locked = false;
    public bool emiting = false;

    private bool keepPressed = false;


    void Start()
    {
        transform.FindChild("Pull").rotation = Quaternion.Euler(315, 0, 0);
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if (!keepPressed)
                    {
                        emiting = !emiting;
                        keepPressed = true;
                    }
                }
                else if (Input.GetKeyUp(KeyCode.E))
                    keepPressed = false;
                else if (Input.GetKeyDown(KeyCode.E))
                    keepPressed = false;


                if (emiting)
                    transform.FindChild("Pull").rotation = Quaternion.Lerp(transform.FindChild("Pull").rotation, Quaternion.Euler(45, 0, 0), 0.1f);
                else
                    transform.FindChild("Pull").rotation = Quaternion.Lerp(transform.FindChild("Pull").rotation, Quaternion.Euler(315, 0, 0), 0.1f);
            }
    }


    void OnTriggerExit(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                keepPressed = false;
    }
}
