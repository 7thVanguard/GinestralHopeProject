using UnityEngine;
using System.Collections;

public class NGGH_AmbientSecondFadeOut : MonoBehaviour 
{
    World world;

    private Color ambient = new Color(5 / 255f, 5 / 255f, 5 / 255f, 1);

    private float timeCounter = 0;
    private bool active;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());
    }


    void Update()
    {
        if (active)
        {
            
            timeCounter -= Time.deltaTime;
            if (timeCounter < 0)
                active = false;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                
                timeCounter = 5;
                active = true;
            }
    }
}
