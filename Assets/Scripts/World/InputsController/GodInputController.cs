using UnityEngine;
using System.Collections;

public class GodInputController : AbstractInputsController 
{
    private Player player;
    private MainCamera mainCamera;

    private DevCombatSkillsManager skills;


    public GodInputController(Player player, MainCamera mainCamera)
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
        EGameFlow.gameMode = EGameFlow.GameMode.GODMODE;
        player.constructionDetection = 300;

        skills.Update(player, mainCamera);
	}
}
