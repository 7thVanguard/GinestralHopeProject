using UnityEngine;
using System.Collections;

public class DeveloperBuildInputController : AbstractInputsController
{
    private World world;
    private Player player;
    private DevConstructionSkills skills;


    public DeveloperBuildInputController(World world, Player player)
    {
        this.world = world;
        this.player = player;
    }


    public override void Start()
    {
        skills = new DevConstructionSkills();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.DEVCONSTRUCTION;
        EGameFlow.generalMode = EGameFlow.GeneralMode.DEVELOPER;
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
                world.selectedTerrain = "Grass";
            else if (Input.GetKey(KeyCode.J))
                world.selectedTerrain = "DirtGrass";
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.SINGLE;
            else if (Input.GetKey(KeyCode.DownArrow))
                EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.ORTOEDRIC;

            if (Input.GetKey(KeyCode.I))
                world.selectedMine = "Rock";
            else if (Input.GetKey(KeyCode.J))
                world.selectedMine = "BrokenRock";
            else if (Input.GetKey(KeyCode.K))
                world.selectedMine = "Wood";
            else if (Input.GetKey(KeyCode.M))
                world.selectedMine = "RockFloor";
            else if (Input.GetKey(KeyCode.N))
                world.selectedMine = "RockWall";
            else if (Input.GetKey(KeyCode.O))
                world.selectedMine = "SmoothRock";
            else if (Input.GetKey(KeyCode.B))
                world.selectedMine = "LittleRocks";
            else if (Input.GetKey(KeyCode.V))
                world.selectedMine = "OtherRock";
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedGadget = EGameFlow.SelectedGadget.PLANK;
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedGadget = EGameFlow.SelectedGadget.WOOD;
            else if (Input.GetKey(KeyCode.K))
                EGameFlow.selectedGadget = EGameFlow.SelectedGadget.NAILS;
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedEnemy = EGameFlow.SelectedEnemy.NORMALSLIME;
        }

        // Mouse click
        skills.Update(world, player);
	}
}
