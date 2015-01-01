using UnityEngine;
using System.Collections;

public class InteractiveComponent : MonoBehaviour 
{
    public World world;                     // Assigned when placing the interactive
    public bool interacting = false;



    public void Interact()
    {
        interacting = true;
    }
}
