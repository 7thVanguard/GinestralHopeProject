using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillDictionary
{
    public static Dictionary<string, Skill> Skill;


    public SkillDictionary()
    {
        Skill = new Dictionary<string, Skill>();
        Init();
    }


    private void Init()
    {
        //+ FireBall
        SDFireBall fireBall = new SDFireBall("Fireball");
        Skill.Add("FireBall", fireBall);
        

    }
}
