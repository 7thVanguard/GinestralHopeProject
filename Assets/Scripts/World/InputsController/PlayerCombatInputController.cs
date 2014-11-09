using UnityEngine;
using System.Collections;

public class PlayerCombatInputController : AbstractInputsController
{
    CombatSkills skills;


    public override void Start()
    {
        skills = new CombatSkills();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.COMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
        SPlayer.constructionDetection = 5;

        skills.Update();
    }
}
