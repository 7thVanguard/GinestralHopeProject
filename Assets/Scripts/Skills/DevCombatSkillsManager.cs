using UnityEngine;
using System.Collections;

public class DevCombatSkillsManager
{
    public void Update(Player player, MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Skill.Dictionary["FireBall"].CastDirected(null, player.playerObj.transform.position, true);
        }
    }
}
