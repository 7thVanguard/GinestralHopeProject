using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NGGH_ThirdInstanceWagon : MonoBehaviour 
{
	public Animation animator;

	void Start() 
	{
		animator = transform.parent.GetComponent<Animation>();
		animator ["Anim01"].speed = 0.5f;
	}


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
				transform.parent.animation.Play();
        }
    }
}
