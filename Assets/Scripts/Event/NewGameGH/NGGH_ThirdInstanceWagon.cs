using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NGGH_ThirdInstanceWagon : MonoBehaviour 
{
    public List<Vector3> List = new List<Vector3>();


    private Quaternion firstTrackQuaternion;
    private Quaternion secondTrackQuaternion;

    private float mapValue;
    private int position = 0;


    void Start()
    {
        firstTrackQuaternion = Quaternion.Euler(0, 90, 90);
        secondTrackQuaternion = Quaternion.Euler(270, 180, 0);
    }


    void Update()
    {
        transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, List[position], 0.02f);

        switch(position)
        {
            case 0:
                transform.parent.localRotation = firstTrackQuaternion;
                break;
            case 1:
                transform.parent.localRotation = firstTrackQuaternion;
                break;
            case 3:
                transform.parent.localRotation = secondTrackQuaternion;
                break;

        }
        if (transform.parent.localPosition.y > -4.323f && transform.parent.localPosition.y < -3.37f)
            transform.parent.localRotation = Quaternion.Lerp(firstTrackQuaternion, secondTrackQuaternion, transform.parent.localPosition.y + 4.323f);

    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (position < List.Count - 1)
                if (Input.GetKeyUp(KeyCode.E))
                    position++;
        }
    }


    private float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
