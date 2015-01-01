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
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            Debug.Log(" Impact point information");
            Debug.Log(mainCamera.raycast.transform.tag);
            Debug.Log((int)mainCamera.raycast.point.x + " " + (int)mainCamera.raycast.point.y + " " + (int)mainCamera.raycast.point.z);
        }

        //++ Tool
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.Alpha1))
                GameFlow.selectedTool = GameFlow.SelectedTool.LIGHT;
            else if (Input.GetKey(KeyCode.Alpha2))
                GameFlow.selectedTool = GameFlow.SelectedTool.MINE;
            else if (Input.GetKey(KeyCode.Alpha3))
                GameFlow.selectedTool = GameFlow.SelectedTool.GEOMETRY;
            else if (Input.GetKey(KeyCode.Alpha4))
                GameFlow.selectedTool = GameFlow.SelectedTool.STRUCTURE;
            else if (Input.GetKey(KeyCode.Alpha5))
                GameFlow.selectedTool = GameFlow.SelectedTool.INTERACTIVE;
			else if (Input.GetKey(KeyCode.Alpha6))
				GameFlow.selectedTool = GameFlow.SelectedTool.ENEMY;
            else if (Input.GetKey(KeyCode.Alpha7))
                GameFlow.selectedTool = GameFlow.SelectedTool.EVENT;
        }

        
        //++ SubTool
        //+ Light
        if (GameFlow.selectedTool == GameFlow.SelectedTool.LIGHT)
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
            //+ Mine
        else if (GameFlow.selectedTool == GameFlow.SelectedTool.MINE)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    GameFlow.developerMineTools = GameFlow.DeveloperMineTools.SINGLE;
                else if (Input.GetKey(KeyCode.Alpha2))
                    GameFlow.developerMineTools = GameFlow.DeveloperMineTools.ORTOEDRIC;
            }
        }
        else if (GameFlow.selectedTool == GameFlow.SelectedTool.GEOMETRY)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    GameFlow.selectedGeometry = "Wooden Bridge 6m";
                else if (Input.GetKey(KeyCode.Alpha2))
                    GameFlow.selectedGeometry = "Wood Pieces";
                else if (Input.GetKey(KeyCode.Alpha3))
                    GameFlow.selectedGeometry = "Bomb";
                else if (Input.GetKey(KeyCode.Alpha4))
                    GameFlow.selectedGeometry = "Torch";
                else if (Input.GetKey(KeyCode.Alpha5))
                    GameFlow.selectedGeometry = "Altar";
                else if (Input.GetKey(KeyCode.Alpha6))
                    GameFlow.selectedGeometry = "Fire Gem";
                else if (Input.GetKey(KeyCode.Alpha7))
                    GameFlow.selectedGeometry = "Iron Pieces";
                else if (Input.GetKey(KeyCode.Alpha8))
                    GameFlow.selectedGeometry = "Chest";
            }
        }
        else if (GameFlow.selectedTool == GameFlow.SelectedTool.STRUCTURE)
        {

        }
        else if (GameFlow.selectedTool == GameFlow.SelectedTool.INTERACTIVE)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    GameFlow.selectedInteractive = "Wooden Plank";
            }
        }
        else if (GameFlow.selectedTool == GameFlow.SelectedTool.ENEMY)
        {
            if (Input.GetKey(KeyCode.Alpha1))
                GameFlow.selectedEnemy = "Normal Slime";
        }

        // Mouse click
        skills.Update(world, player, mainCamera);
	}
}
