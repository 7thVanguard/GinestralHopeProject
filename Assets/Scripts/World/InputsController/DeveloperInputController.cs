using UnityEngine;
using System.Collections;

public class DeveloperInputController : AbstractInputsController
{
    private World world;
    private Player player;
    private MainCamera mainCamera;
    private DevConstructionSkillsManager skills;


    public DeveloperInputController(World world, Player player, MainCamera mainCamera)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;
    }


    public override void Start()
    {
        skills = new DevConstructionSkillsManager();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.DEVELOPER;
        player.constructionDetection = 300;


        // Tool
        if (Input.GetKey(KeyCode.Alpha1))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.TERRAIN;
        else if (Input.GetKey(KeyCode.Alpha2))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.MINE;
        else if (Input.GetKey(KeyCode.Alpha3))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.GADGET;
        else if (Input.GetKey(KeyCode.Alpha4))
            EGameFlow.selectedTool = EGameFlow.SelectedTool.ENEMY;

        
        // SubTool
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedTerrain = "Grass";
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedTerrain = "DirtGrass";
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.SINGLE;
            else if (Input.GetKey(KeyCode.DownArrow))
                EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.ORTOEDRIC;

            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedMine = "Rock";
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedMine = "BrokenRock";
            else if (Input.GetKey(KeyCode.K))
                EGameFlow.selectedMine = "Wood";
            else if (Input.GetKey(KeyCode.M))
                EGameFlow.selectedMine = "RockFloor";
            else if (Input.GetKey(KeyCode.N))
                EGameFlow.selectedMine = "RockWall";
            else if (Input.GetKey(KeyCode.O))
                EGameFlow.selectedMine = "SmoothRock";
            else if (Input.GetKey(KeyCode.B))
                EGameFlow.selectedMine = "LittleRocks";
            else if (Input.GetKey(KeyCode.V))
                EGameFlow.selectedMine = "OtherRock";
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedGadget = "Wooden Plank";
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedGadget = "Wood Pieces";
            else if (Input.GetKey(KeyCode.K))
                EGameFlow.selectedGadget = "Nails";
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedEnemy = "Normal Slime";
        }

        // Mouse click
        skills.Update(world, player, mainCamera);
	}
}
