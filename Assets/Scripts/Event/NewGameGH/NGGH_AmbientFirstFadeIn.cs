using UnityEngine;
using System.Collections;

public class NGGH_AmbientFirstFadeIn : MonoBehaviour
{
    World world;

    private Color ambient = new Color(214 / 255f, 220 / 255f, 200 / 255f, 1);

    private float timeCounter = 0;
    private bool active;


    void Start()
    {
        BoxCollider boxCollider;
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(5, 5, 0.2f);
        boxCollider.isTrigger = true;
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());
    }


    void Update()
    {
        if (active)
        {
            EventsLib.UpdateRenderades();
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
                EventsLib.UpdateRenderades(ambient);
                timeCounter = 5;
                active = true;
            }
    }
}
