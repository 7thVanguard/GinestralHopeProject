using UnityEngine;
using System.Collections;

public class DevCombatSkills
{
    Skill selectedSkill;


    public void Update(MainCamera mainCamera)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            selectedSkill = SkillDictionary.Skill["FireBall"];
            selectedSkill.CastDirected(mainCamera, null, SPlayer.transform.position, 25, 30, true);
        }
    }
}
