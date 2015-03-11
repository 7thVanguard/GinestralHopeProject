using UnityEngine;
using System.Collections;

public class NGGH_FirstInstanceColumn : MonoBehaviour 
{
    public GameObject column;
    private bool finished = false;


    void OnTriggerStay(Collider other)
    {
        if (!finished)
            if (other.tag == "Player")
            {
                column.animation.Play();
                finished = true;
            }
    }
}
