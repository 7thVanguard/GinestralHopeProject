using UnityEngine;
using System.Collections;

public class PlayerCombatInputController : AbstractInputsController
{
    public override void Start()
    {
        
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.COMBAT;
        EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
        SPlayer.constructionDetection = 5;
    }
}
