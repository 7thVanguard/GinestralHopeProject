using UnityEngine;
using System.Collections;

public class DevCombatSkillsManager
{
    Skill selectedSkill;


    public void Update(Player player, MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSkill = Skill.Dictionary["FireBall"];
            selectedSkill.CastDirected(null, player.playerObj.transform.position, true);
        }
    }
}
