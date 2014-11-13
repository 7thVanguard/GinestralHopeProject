using UnityEngine;
using System.Collections;

public class DevCombatSkillsManager
{
    Skill selectedSkill;


    public void Update(MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            selectedSkill = SkillDictionary.Skills["FireBall"];
            selectedSkill.CastDirected(mainCamera, null, SPlayer.transform.position, true);
        }
    }
}
