using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    // Inspector variables
    public Flare sunFlare;


    // Controllers
    private Dictionary<string, GameController> Controllers;

    private GameController activeController;


    // GameObjects
    private GameObject player;
    private GameObject mainCamera;
    private GameObject world;


    void Awake()
    {
        //+ Object Init
        world = gameObject;
        ObjectCreator.WorldSet(world);

        player = ObjectCreator.PlayerCreation();
        mainCamera = ObjectCreator.CameraCreation();
        ObjectCreator.SunCreation(sunFlare);


        //+ Game modes
        Controllers = new Dictionary<string, GameController>();

        GameController aPC = new PlayerCombatGameController(player, mainCamera);
        aPC.Start();
        Controllers.Add("PlayerCombatMode", aPC);

        aPC = new PlayerBuildGameController(player, mainCamera);
        aPC.Start();
        Controllers.Add("PlayerBuildMode", aPC);

        aPC = new DeveloperCombatGameController(player, mainCamera);
        aPC.Start();
        Controllers.Add("DeveloperCombatMode", aPC);

        aPC = new DeveloperBuildGameController(player, mainCamera);
        aPC.Start();
        Controllers.Add("DeveloperBuildMode", aPC);

        activeController = Controllers["DeveloperBuildMode"];
    }


    void Update()
    {
        // Game mode
        if (Input.GetKey(KeyCode.F1))
            activeController = Controllers["PlayerBuildMode"];
        else if (Input.GetKey(KeyCode.F2))
            activeController = Controllers["PlayerCombatMode"];
        else if (Input.GetKey(KeyCode.F3))
            activeController = Controllers["DeveloperCombatMode"];
        else if (Input.GetKey(KeyCode.F4))
            activeController = Controllers["DeveloperBuildMode"];

        activeController.Update();
    }
}