using UnityEngine;
using System.Collections;

public class EventComponent : MonoBehaviour 
{
    [HideInInspector] public World world;
    [HideInInspector] public Player player;



	void Start ()
    {
        if (this.name != "none")
        {
            this.gameObject.name = this.name;
            this.gameObject.AddComponent(this.name);
        }
	}
}
