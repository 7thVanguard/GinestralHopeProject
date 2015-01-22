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
            Debug.Log(mainCamera.raycast.point.x + " " + mainCamera.raycast.point.y + " " + mainCamera.raycast.point.z);
        }

        //++ Tool
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.Alpha1))
                GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().LightButton();
            else if (Input.GetKey(KeyCode.Alpha2))
                GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().VoxelButton();
            else if (Input.GetKey(KeyCode.Alpha3))
                GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().GeometryButton();
            else if (Input.GetKey(KeyCode.Alpha4))
                GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().StructureButton();
            else if (Input.GetKey(KeyCode.Alpha5))
                GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().InteractiveButton();
			else if (Input.GetKey(KeyCode.Alpha6))
                GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().EnemyButton();
            else if (Input.GetKey(KeyCode.Alpha7))
                GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().EventButton();
        }
        //++ SubTool
        else
        {
            if (GameFlow.selectedTool == GameFlow.SelectedTool.LIGHT)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().SunRiseButton();
                else if (Input.GetKey(KeyCode.Alpha2))
                    GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().MidDayButton();
                else if (Input.GetKey(KeyCode.Alpha3))
                    GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().EveningButton();
                else if (Input.GetKey(KeyCode.Alpha4))
                    GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().NightButton();
            }
            else if (GameFlow.selectedTool == GameFlow.SelectedTool.VOXEL)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().SingleVoxelButton();
                else if (Input.GetKey(KeyCode.Alpha2))
                    GameGUI.developerMode.transform.parent.FindChild("UI Controller Developer Mode").GetComponent<GUIDeveloperMode>().OrtoedricVoxelButton();
            }
            else if (GameFlow.selectedTool == GameFlow.SelectedTool.GEOMETRY)
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
            else if (GameFlow.selectedTool == GameFlow.SelectedTool.STRUCTURE)
            {

            }
            else if (GameFlow.selectedTool == GameFlow.SelectedTool.INTERACTIVE)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    GameFlow.selectedInteractive = "Wooden Plank";
            }
            else if (GameFlow.selectedTool == GameFlow.SelectedTool.ENEMY)
            {
                if (Input.GetKey(KeyCode.Alpha1))
                    GameFlow.selectedEnemy = "Normal Slime";
            }
            else if (GameFlow.selectedTool == GameFlow.SelectedTool.EVENT)
            {

            }
        }
        

        skills.Update(world, player, mainCamera);
	}
}
