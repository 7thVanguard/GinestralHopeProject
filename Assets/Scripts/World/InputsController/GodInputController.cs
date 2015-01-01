using UnityEngine;
using System.Collections;

public class GodInputController : AbstractInputsController 
{
    private Player player;
    private MainCamera mainCamera;

    private DevCombatToolsManager skills;


    public GodInputController(Player player, MainCamera mainCamera)
    {
        this.player = player;
        this.mainCamera = mainCamera;
    }


	public override void Start()
    {
        skills = new DevCombatToolsManager();
	}
	


    public override void Update()
    {
        skills.Update(player, mainCamera);
	}
}
