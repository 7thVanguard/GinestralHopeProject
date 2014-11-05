using UnityEngine;
using System.Collections;

public class PlayerCombat
{
    private GameObject player;

    // Detection relative
    public static GameObject target;
    public static Vector3 circleGizmoScreenPos;
    private int detectionDistance = 30;

    // Damage relative
    public Color originalColor;
    private int animCounter;


    public void Start(GameObject player)
    {
        this.player = player;

        // Detection relative
        target = null;
        circleGizmoScreenPos = Vector3.zero;

        // Damage relative
        originalColor = player.renderer.material.color;
        animCounter = 0;
    }


    public void Update()
    {
        // Detection relative
        if (CameraRaycast.impact.distance < detectionDistance && CameraRaycast.impact.distance != 0)
            if (CameraRaycast.impact.transform.tag == "Enemy")
                target = CameraRaycast.impact.transform.gameObject;


        if (target != null)
        {
            circleGizmoScreenPos = Camera.main.WorldToScreenPoint(target.transform.position);

            // Abandon target
            if (Vector3.Distance(SPlayer.transform.position, target.transform.position) > detectionDistance)
                target = null;

            if (Vector2.Distance(new Vector2(circleGizmoScreenPos.x, circleGizmoScreenPos.y), new Vector2(Screen.width / 2, Screen.height / 2)) > Screen.height / 2.5f)
                target = null;
        }


        // Hit animation
        if (animCounter > 0)
        {
            animCounter--;
            if (animCounter == 0)
                player.renderer.material.color = originalColor;
        }
    }


    public void Damage(float damage)
    {
        SPlayer.currentLife -= damage;
        DamageAnim();

        // Player dead
        if (SPlayer.currentLife <= 0)
            Object.Destroy(player);
    }


    private void DamageAnim()
    {
        animCounter = SPlayer.damageAnimTime;

        player.renderer.material.color = Color.red;
    }
}
