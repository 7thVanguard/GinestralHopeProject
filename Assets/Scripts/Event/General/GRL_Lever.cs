using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GRL_Lever : MonoBehaviour 
{
    public List<GameObject> List = new List<GameObject>();

    public bool emitting = false;
    private bool keepPressed = false;


    void Start()
    {
        if (emitting)
            transform.FindChild("Pull").localRotation = Quaternion.Euler(45, 0, 0);
        else
            transform.FindChild("Pull").localRotation = Quaternion.Euler(315, 0, 0);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (!keepPressed)
                {
                    emitting = !emitting;
                    keepPressed = true;
                    transform.audio.Play();
                }
            }
            else if (Input.GetKeyUp(KeyCode.E))
                keepPressed = false;


            if (emitting)
            {
                transform.FindChild("Pull").localRotation = Quaternion.Lerp(transform.FindChild("Pull").localRotation, Quaternion.Euler(45, 0, 0), 0.1f);

                foreach (GameObject go in List)
                    go.SetActive(true);
            }
            else
            {
                transform.FindChild("Pull").localRotation = Quaternion.Lerp(transform.FindChild("Pull").localRotation, Quaternion.Euler(315, 0, 0), 0.1f);

                foreach (GameObject go in List)
                    go.SetActive(false);
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
                keepPressed = false;

        if (emitting)
            transform.FindChild("Pull").localRotation = Quaternion.Euler(45, 0, 0);
        else
            transform.FindChild("Pull").localRotation = Quaternion.Euler(315, 0, 0);
    }
}
