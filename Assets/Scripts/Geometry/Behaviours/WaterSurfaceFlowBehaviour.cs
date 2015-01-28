using UnityEngine;
using System.Collections;

public class WaterSurfaceFlowBehaviour : MonoBehaviour 
{
    float offset = 0;
    float timeCounter = 0;


    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 0.035f)
        {
            timeCounter = 0;
            offset += 0.03125f;
            if (offset >= 1)
                offset -= 1;
        }
        transform.renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
