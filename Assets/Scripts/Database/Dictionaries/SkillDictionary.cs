using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillDictionary
{
    public static Dictionary<string, Skill> Skills;


    public SkillDictionary()
    {
        Skills = new Dictionary<string, Skill>();
        Init();
    }


    private void Init()
    {
        //+ FireBall
        SDFireBall fireBall = new SDFireBall("FireBall");

        fireBall.ID = "FireBall";
        fireBall.objectSpeed = 25;
        fireBall.maxDistance = 30;

        Skills.Add(fireBall.ID, fireBall);
        fireBall.Init();
    }
}
