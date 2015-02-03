using UnityEngine;
using System.Collections;

public class LavaSurfaceStillBehaviour : MonoBehaviour 
{
    Vector2 offset = Vector2.zero;
    float timeCounter = 0;


    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 0.05f)
        {
            timeCounter = 0;
            offset.y += 0.125f;
            if (offset.y >= 0.875f)
            {
                offset.y = 0;
                offset.x += 0.125f;

                if (offset.x >= 0.75f)
                    offset = Vector2.zero;
            }
        }
        transform.renderer.material.mainTextureOffset = offset;
    }
}
