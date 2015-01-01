using UnityEngine;
using System.Collections;

public class ToolsClosetBehaviour : MonoBehaviour 
{
    void Update()
    {
        if (transform.GetComponent<InteractiveComponent>().interacting)
            Interacting();
    }


    public void Interacting()
    {
        if (Input.GetKeyUp(KeyCode.X))
            transform.GetComponent<InteractiveComponent>().interacting = false;
    }
}
