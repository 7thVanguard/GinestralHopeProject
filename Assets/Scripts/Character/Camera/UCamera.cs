using UnityEngine;
using System.Collections;

public class UCamera : MonoBehaviour
{


	void Start ()
    {
        //transform.localPosition = SPlayer.transform.position + new Vector3(0, 0, -10);
        transform.localEulerAngles = Vector3.zero;

        gameObject.GetComponent<CharacterController>().transform.localScale = new Vector3(0.3f, 0.15f, 0.3f);
	}
	

	void LateUpdate ()
    {

	}
}
