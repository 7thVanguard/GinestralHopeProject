using UnityEngine;
using System.Collections;

public class DevCombatSkillsManager
{
    Skill selectedSkill;


    public void Update(Player player, MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            selectedSkill = SkillDictionary.Skills["FireBall"];
            selectedSkill.CastDirected(player, mainCamera, null, player.playerObj.transform.position, true);
        }
    }
}
