using UnityEngine;
using System.Collections;

public class DevCombatSkills
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CreateLambertBall.Cast(SPlayer.transform.position, 25, 30, true);
    }
}
