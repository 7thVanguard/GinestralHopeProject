using UnityEngine;
using System.Collections;

public class GRL_ContactPlatform : MonoBehaviour 
{
    public Vector3 initialPosition;
    public Vector3 endPosition;
    public float duration;

    private float interpolation = 0;
    private bool onStay = false;


    void Sttart()
    {
        if (duration < 1)
            duration = 1;
    }


    void Update()
    {
        if (onStay)
            interpolation += Time.deltaTime / duration;
        else
            interpolation -= Time.deltaTime / duration;

        interpolation = Mathf.Clamp(interpolation, 0, 1);
        transform.position = Vector3.Slerp(initialPosition, endPosition, interpolation);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            onStay = true;
            Global.player.playerObj.transform.parent = transform;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onStay = false;
            Global.player.playerObj.transform.parent = null;
        }
    }
}
