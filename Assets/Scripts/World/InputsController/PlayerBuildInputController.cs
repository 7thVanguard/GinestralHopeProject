using UnityEngine;
using System.Collections;

public class PlayerBuildInputController : AbstractInputsController 
{
    private World world;
    private Player player;
    private MainCamera mainCamera;

    private ConstructionSkillsManager skills;


    public PlayerBuildInputController(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        skills = new ConstructionSkillsManager();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.CONTRUCTION;
        EGameFlow.generalMode = EGameFlow.GeneralMode.PLAYER;
        player.constructionDetection = 5;

        // Tools
        if (Input.GetKey(KeyCode.Alpha3))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.GADGET;


        // Subtools
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedGadget = "Wooden Plank";
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedGadget = "Wood Pieces";
            else if (Input.GetKey(KeyCode.K))
                EGameFlow.selectedGadget = "Nails";
        }

        skills.Update(world, player, mainCamera);
    }
}
