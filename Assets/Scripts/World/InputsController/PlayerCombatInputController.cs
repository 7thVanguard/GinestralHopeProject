using UnityEngine;
using System.Collections;

public class PlayerCombatInputController : AbstractInputsController
{
    Player player;
    CombatSkills skills;


    public PlayerCombatInputController(Player player)
    {
        this.player = player;
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

        skills.Update();
    }
}
