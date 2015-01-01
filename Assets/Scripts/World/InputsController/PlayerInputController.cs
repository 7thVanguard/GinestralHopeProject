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
        if (!GameFlow.pause)
        {
            // Impact information
            if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                Debug.Log(" Impact point information");
                Debug.Log(mainCamera.raycast.transform.tag);
                Debug.Log((int)mainCamera.raycast.point.x + " " + (int)mainCamera.raycast.point.y + " " + (int)mainCamera.raycast.point.z);
            }

            if (Input.GetKeyUp(KeyCode.E))
                if (mainCamera.raycast.transform.tag == "Interactive")
                    mainCamera.raycast.transform.GetComponent<InteractiveComponent>().interacting = true;

            //constructionSkills.Update(world, player, mainCamera);
            combatSkills.Update(player, mainCamera);
        }
    }
}
