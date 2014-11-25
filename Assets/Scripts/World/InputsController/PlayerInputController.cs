using UnityEngine;
using System.Collections;

public class PlayerInputController : AbstractInputsController 
{
    private World world;
    private Player player;
    private MainCamera mainCamera;

    private ConstructionToolsManager constructionSkills;
    private CombatToolsManager combatSkills;



    public PlayerInputController(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        constructionSkills = new ConstructionToolsManager();
        combatSkills = new CombatToolsManager();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.PLAYER;
        player.constructionDetection = 5;

        // Tools
        if (Input.GetKey(KeyCode.Alpha3))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.GADGET;


        // Subtools
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedGadget = "Wooden Plank";
        }

        if (!EGameFlow.pause)
        {
            constructionSkills.Update(world, player, mainCamera);
            combatSkills.Update(player, mainCamera);
        }
    }
}
