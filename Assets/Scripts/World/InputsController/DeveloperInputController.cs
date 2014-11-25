using UnityEngine;
using System.Collections;

public class DeveloperInputController : AbstractInputsController
{
    private World world;
    private Player player;
    private MainCamera mainCamera;
    private Sun sun;

    private DevConstructionToolsManager skills;


    public DeveloperInputController(World world, Player player, MainCamera mainCamera, Sun sun)
    {
        this.world = world;
        this.player = player;
        this.mainCamera = mainCamera;
        this.sun = sun;
    }


    public override void Start()
    {
        skills = new DevConstructionToolsManager();
    }


    public override void Update()
    {
        EGameFlow.gameMode = EGameFlow.GameMode.DEVELOPER;
        player.constructionDetection = 300;

        //+ Tool
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.Alpha1))
                EGameFlow.selectedTool = EGameFlow.SelectedTool.LIGHT;
            else if (Input.GetKey(KeyCode.Alpha3))
                EGameFlow.selectedTool = EGameFlow.SelectedTool.MINE;
            else if (Input.GetKey(KeyCode.Alpha4))
                EGameFlow.selectedTool = EGameFlow.SelectedTool.GADGET;
            else if (Input.GetKey(KeyCode.Alpha5))
                EGameFlow.selectedTool = EGameFlow.SelectedTool.ENEMY;
        }

        
        //+ SubTool
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.LIGHT)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    sun.lightSystemBehaviour.SetSunRise();
                else if (Input.GetKey(KeyCode.Alpha2))
                    sun.lightSystemBehaviour.SetMidDay();
                else if (Input.GetKey(KeyCode.Alpha3))
                    sun.lightSystemBehaviour.SetNoon();
                else if (Input.GetKey(KeyCode.Alpha4))
                    sun.lightSystemBehaviour.SetNight();
            }
        }
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedTerrain = "Grass";
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedTerrain = "DirtGrass";
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.SINGLE;
                else if (Input.GetKey(KeyCode.Alpha2))
                    EGameFlow.developerMineTools = EGameFlow.DeveloperMineTools.ORTOEDRIC;
            }
        }
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
        {
            if (Input.GetKey(KeyCode.I))
                EGameFlow.selectedGadget = "Wooden Plank";
            else if (Input.GetKey(KeyCode.J))
                EGameFlow.selectedGadget = "Wood Pieces";
            else if (Input.GetKey(KeyCode.K))
                EGameFlow.selectedGadget = "Torch";
            else if (Input.GetKey(KeyCode.B))
                EGameFlow.selectedGadget = "Bomb";
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
