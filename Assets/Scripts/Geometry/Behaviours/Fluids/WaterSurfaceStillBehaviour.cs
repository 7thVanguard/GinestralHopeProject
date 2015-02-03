using UnityEngine;
using System.Collections;

public class WaterSurfaceStillBehaviour : MonoBehaviour 
{
    float offset = 0;
    float timeCounter = 0;
    

    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 0.05f)
        {
            timeCounter = 0;
            offset += 0.0625f;
            if (offset >= 1)
                offset -= 1;
        }
        transform.renderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
