using UnityEngine;
using System.Collections;

public class DevCombatSkills
{
    public void Update(MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CreateLambertBall.Cast(mainCamera, SPlayer.transform.position, 25, 30, true);
    }
}
