using UnityEngine;
using System.Collections;

public class PlayerCombat
{
    private Player player;
    MainCamera mainCamera;

    // Detection relative
    public static GameObject target;
    public static Vector3 circleGizmoScreenPos;
    private int detectionDistance = 30;


    public PlayerCombat(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;

        // Detection relative
        target = null;
        circleGizmoScreenPos = Vector3.zero;
    }


    public void Update()
    {
        // Detection relative
        if (mainCamera.raycast.distance < detectionDistance && mainCamera.raycast.distance != 0)
            if (mainCamera.raycast.transform.tag == "Enemy")
                target = mainCamera.raycast.transform.gameObject;


        if (target != null)
        {
            circleGizmoScreenPos = Camera.main.WorldToScreenPoint(target.transform.position);

            // Abandon target
            if (Vector3.Distance(player.playerObj.transform.position, target.transform.position) > detectionDistance)
                target = null;

            if (Vector2.Distance(new Vector2(circleGizmoScreenPos.x, circleGizmoScreenPos.y), new Vector2(Screen.width / 2, Screen.height / 2)) > Screen.height / 2.5f)
                target = null;
        }
    }
}
