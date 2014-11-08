using UnityEngine;
using System.Collections;

public class PlayerBuildInputController : AbstractInputsController 
{
    public override void Start()
    {
        
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.CONTRUCTION;
        EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
        SPlayer.constructionDetection = 5;

        // Tools
        if (Input.GetKey(KeyCode.Alpha3))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.GADGET;


        // Subtools
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedGadget = EGameFlow.SelectedGadget.PLANK;
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedGadget = EGameFlow.SelectedGadget.WOOD;
            else if (Input.GetKey(KeyCode.K))
                EGameFlow.selectedGadget = EGameFlow.SelectedGadget.NAILS;
        }
    }
}
