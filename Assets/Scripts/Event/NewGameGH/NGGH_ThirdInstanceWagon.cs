using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NGGH_ThirdInstanceWagon : MonoBehaviour 
{
    public List<Vector3> List = new List<Vector3>();

    private int position = 0;


    void Update()
    {
        transform.parent.localPosition = Vector3.Lerp(transform.parent.localPosition, List[position], 0.1f);
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.E))
                position++;
        }
    }
}
