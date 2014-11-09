using UnityEngine;
using System.Collections;

public class DeveloperCombatInputController : AbstractInputsController 
{
    private DevCombatSkills skills;


	public override void Start()
    {
        skills = new DevCombatSkills();
	}
	


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.DEVCOMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.DEVELOPER;
        SPlayer.constructionDetection = 300;

        skills.Update();
	}
}
