using UnityEngine;
using System.Collections;

public class NGGH_FirstLightsOn : MonoBehaviour 
{
    World world;

    GameObject firstLight;
    GameObject secondLight;


    void Start()
    {
        this.world = gameObject.GetComponent<EventComponent>().world;
        Transform.Destroy(gameObject.GetComponent<EventComponent>());

        // Deactivate lights
        RaycastHit impact;

        if (Physics.Raycast(new Vector3(22.5f, 4.5f, 10), new Vector3(0, 0, -1), out impact, 5))
            firstLight = impact.transform.gameObject;
        if (Physics.Raycast(new Vector3(22.5f, 4.5f, 11), new Vector3(0, 0, 1), out impact, 5))
            secondLight = impact.transform.gameObject;
    }


    void OnTriggerStay(Collider other)
    {
        if (GameFlow.gameMode == GameFlow.GameMode.PLAYER)
            if (other.tag == "Player")
            {
                firstLight.SetActive(true);
                secondLight.SetActive(true);
            }
    }
}
