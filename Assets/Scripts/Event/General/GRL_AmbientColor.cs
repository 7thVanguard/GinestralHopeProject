using UnityEngine;
using System.Collections;

public class GRL_AmbientColor : MonoBehaviour 
{
    public Color ambient;

    private float timeCounter = 0;
    private bool active;


	void Update ()
    {
        if (active)
        {
            EventsLib.UpdateRenderambient();
            EventsLib.UpdateDoorOpenDoubleSlider();

            timeCounter -= Time.deltaTime;
            if (timeCounter < 0)
                active = false;
        }
	}


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            EventsLib.SetRenderambient(ambient);

            timeCounter = 10;
            active = true;
        }
    }
}
