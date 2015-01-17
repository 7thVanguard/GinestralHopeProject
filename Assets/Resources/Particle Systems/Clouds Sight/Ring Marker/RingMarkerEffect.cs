using UnityEngine;
using System.Collections;

public class RingMarkerEffect : MonoBehaviour 
{
    private float timeCounter = 1.2f;       // Time till destruction

	void Update() 
    {
        timeCounter -= Time.deltaTime;

        if (timeCounter <= 0)
            Transform.Destroy(this.gameObject);
	}
}
