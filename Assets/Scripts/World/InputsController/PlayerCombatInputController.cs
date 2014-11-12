using UnityEngine;
using System.Collections;

public class PlayerCombatInputController : AbstractInputsController
{
    Player player;
    MainCamera mainCamera;
    CombatSkillsManager skills;


    public PlayerCombatInputController(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        skills = new CombatSkillsManager();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.COMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
        player.constructionDetection = 5;

        skills.Update(mainCamera);
    }
}
