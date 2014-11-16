using UnityEngine;
using System.Collections;

public class DeveloperCombatInputController : AbstractInputsController 
{
    private Player player;
    private MainCamera mainCamera;

    private DevCombatSkillsManager skills;


    public DeveloperCombatInputController(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


	public override void Start()
    {
        skills = new DevCombatSkillsManager();
	}
	


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.DEVCOMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.DEVELOPER;
        player.constructionDetection = 300;

        skills.Update(player, mainCamera);
	}
}
