using UnityEngine;
using System.Collections;

public class NSlimeCombat
{
    GameObject enemy;
    RaycastHit impact;
    
    private Vector3 playerFocus;            // Vector that goes from enemy to player
    private float dotProduct;
    private int detectionDistance = 30;


    public void Start(GameObject enemy)
    {
        this.enemy = enemy;
    }


    public void Update(MainCamera mainCamera, GameObject enemy)
    {
        if (Time.time % 1 == 0)
            Detection(mainCamera);
    }


    private void Detection(MainCamera mainCamera)
    {
        // Player is in enemy radius
        if (Vector3.Distance(SPlayer.transform.position, enemy.transform.position) < detectionDistance)
        {
            // Calculates enemy vision
            playerFocus = SPlayer.transform.position - enemy.transform.position;
            playerFocus.Normalize();

            // Calculates player position respect to this enemy
            dotProduct = Vector3.Dot(enemy.transform.forward, playerFocus);

            // Player is in the sight cone
            if (dotProduct > 0.55f)
            {
                // Check if player is visible
                if (Physics.Raycast(enemy.transform.position, playerFocus, out impact, 30))
                    if (impact.transform.gameObject.tag == "Player")
                        CreateLambertBall.Cast(mainCamera, enemy.transform.position, 25, 30, false);
            }
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
