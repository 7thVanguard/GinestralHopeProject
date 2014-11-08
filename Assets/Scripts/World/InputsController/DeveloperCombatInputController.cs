using UnityEngine;
using System.Collections;

public class DeveloperCombatInputController : AbstractInputsController 
{
	public override void Start()
    {
	
	}
	


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.DEVCOMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.DEVELOPER;
        SPlayer.constructionDetection = 300;
	}
}
