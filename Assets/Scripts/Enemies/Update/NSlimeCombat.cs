using UnityEngine;
using System.Collections;

public class NSlimeCombat
{
    GameObject enemy;
    
    private Vector3 playerFocus;
    private float dot;
    private int detectionDistance = 30;


    public void Start(GameObject enemy)
    {
        this.enemy = enemy;
    }


    public void Update(GameObject enemy)
    {
        if (Time.time % 1 == 0)
            Detection();
    }


    private void Detection()
    {
        // Player is in enemy radius
        if (Vector3.Distance(SPlayer.transform.position, enemy.transform.position) < detectionDistance)
        {
            // Calculates enemy vision

            playerFocus = SPlayer.transform.position - enemy.transform.position;
            playerFocus.Normalize();

            // Calculates player position respect to this enemy
            dot = Vector3.Dot(enemy.transform.forward, playerFocus);

            if (dot > 0.55f)
                Debug.Log("detected");
        }
    }


    private void RecalculateAnngles(ref float angle)
    {
        if (angle >= 360)
            angle -= 360;
        else if (angle < 0)
            angle += 360;
    }
}
