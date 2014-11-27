using UnityEngine;
using System.Collections;

public class EventComponent : MonoBehaviour 
{
    public enum TriggerShape { NONE, SPHERE, ORTOEDRIC }
    public enum EventType { None, EraseTorch, EraseVoxels, PutTorch, PutVoxels }
    

    public EventType eventType;



	void Start ()
    {
        if (eventType != EventType.None)
        {
            this.gameObject.name = eventType.ToString();
            this.gameObject.AddComponent(eventType.ToString());
        }
	}
}
