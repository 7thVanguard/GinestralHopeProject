using UnityEngine;
using System.Collections;

public class GRL_ConstantPlatform : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 endPosition;
    public float duration;

    private float interpolation = 0;
    private bool toEndPos = false;


    void Sttart()
    {
        if (duration < 1)
            duration = 1;
    }


    void Update()
    {
        if (toEndPos)
            interpolation += Time.deltaTime / duration;
        else
            interpolation -= Time.deltaTime / duration;

        if (interpolation > 0.99f)
            toEndPos = false;
        else if (interpolation < 0.01f)
            toEndPos = true;

        interpolation = Mathf.Clamp(interpolation, 0, 1);
        transform.position = Vector3.Slerp(initialPosition, endPosition, interpolation);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            Global.player.playerObj.transform.parent = transform;
    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Global.player.playerObj.transform.parent = null;
    }
}
