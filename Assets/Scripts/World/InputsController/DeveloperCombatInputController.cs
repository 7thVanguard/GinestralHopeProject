using UnityEngine;
using System.Collections;

public class DeveloperCombatInputController : AbstractInputsController 
{
    private Player player;
    private DevCombatSkills skills;


    public DeveloperCombatInputController(Player player)
    {
        this.player = player;
    }


	public override void Start()
    {
        skills = new DevCombatSkills();
	}
	


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.DEVCOMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.DEVELOPER;
        player.constructionDetection = 300;

        skills.Update();
	}
}
