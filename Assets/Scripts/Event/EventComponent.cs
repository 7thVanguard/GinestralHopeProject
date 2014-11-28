using UnityEngine;
using System.Collections;

public class EventComponent : MonoBehaviour 
{
	void Start ()
    {
        if (this.name != "none")
        {
            this.gameObject.name = this.name;
            this.gameObject.AddComponent(this.name);
            Transform.Destroy(this.gameObject.GetComponent<EventComponent>());
        }
	}
}
