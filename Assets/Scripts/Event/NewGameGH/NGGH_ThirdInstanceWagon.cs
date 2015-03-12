using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NGGH_ThirdInstanceWagon : MonoBehaviour
{
    private Animation animator;
    private float counter = 0;
    private float timeToCount = 3;

    private bool animationDone = false;     
    private bool ready;                     // When ready to pick up the light
	

	void Start() 
	{
		animator = transform.parent.GetComponent<Animation>();
		animator ["Anim01"].speed = 0.5f;
	}


    void Update()
    {
        // Count three seconds from pushing the minecrat before we can pick up the light
        if (animationDone && !ready)
        {
            counter += Time.deltaTime;

            if (counter >= timeToCount)
                ready = true;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                // Push the MineCart
                if (!animationDone)
                {
                    transform.parent.animation.Play();
                    animationDone = true;
                }
                // Player pick up light
                else if (ready)
                {
                    GameObject lamp = transform.parent.FindChild("Lamp").gameObject;
                    lamp.transform.parent = Global.player.playerObj.transform.FindChild("Mesh");
                    lamp.transform.localPosition = new Vector3(0.3f, 0.5f, 0);
                    Destroy(transform.GetComponent<NGGH_ThirdInstanceWagon>());
                }
            }
        }
    }
}
