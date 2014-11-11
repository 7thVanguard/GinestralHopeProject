using UnityEngine;
using System.Collections;

public class PlayerCombatInputController : AbstractInputsController
{
    Player player;
    MainCamera mainCamera;
    CombatSkills skills;


    public PlayerCombatInputController(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        skills = new CombatSkills();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.COMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
        player.constructionDetection = 5;

        skills.Update(mainCamera);
    }
}
