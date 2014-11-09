using UnityEngine;
using System.Collections;

public class PlayerBuildInputController : AbstractInputsController 
{
    private World world;
    private ConstructionSkills skills;


    public PlayerBuildInputController(World world)
    {
        this.world = world;
    }


    public override void Start()
    {
        skills = new ConstructionSkills();
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

        skills.Update(world);
    }
}
