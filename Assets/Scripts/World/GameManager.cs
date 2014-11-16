using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    // Inspector variables
    public Transform prefabs;
    public Material atlas;
    public Flare sunFlare;
    public string saveName;


    // Controllers
    private Dictionary<string, GameController> Controller;

    private GameController activeController;
    private SkillDictionary skillDictionary;
    private EnemyDictionary enemyDictionary;


    // Main control classes
    private World world;
    private Player player;
    private MainCamera mainCamera;
    private Sun sun;
    

    // Save
    EGameSerializer gameSerializer;


    void Awake()
    {
        //+ Object Init
        world = new World(gameObject, prefabs, atlas);
        player = new Player();
        mainCamera = new MainCamera();
        sun = new Sun(player, sunFlare);

        // post initialize
        world.worldObj.GetComponent<HUD>().Init(player);
        sun.lightSystemBehaviour.Init(player, sun.sunObj, sun.lensFlare);


        //+ Controllers Init
        Controller = new Dictionary<string, GameController>();
        skillDictionary = new SkillDictionary();
        enemyDictionary = new EnemyDictionary();



        //+ Game modes
        GameController aPC;

        aPC = new PlayerCombatGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("PlayerCombatMode", aPC);

        aPC = new PlayerBuildGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("PlayerBuildMode", aPC);

        aPC = new DeveloperCombatGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("DeveloperCombatMode", aPC);

        aPC = new DeveloperBuildGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("DeveloperBuildMode", aPC);

        activeController = Controller["DeveloperBuildMode"];

        gameSerializer = new EGameSerializer();
    }


    void Update()
    {
        //+ Global inputs
        // Game mode
        if (Input.GetKey(KeyCode.F1))
            activeController = Controller["PlayerCombatMode"];
        else if (Input.GetKey(KeyCode.F2))
            activeController = Controller["PlayerBuildMode"];
        else if (Input.GetKey(KeyCode.F3))
            activeController = Controller["DeveloperCombatMode"];
        else if (Input.GetKey(KeyCode.F4))
            activeController = Controller["DeveloperBuildMode"];

        // Pause
        if (Input.GetKeyUp(KeyCode.P))
            EGameFlow.pause = !EGameFlow.pause;

        // Save relative
        if (Input.GetKeyUp(KeyCode.F5))
            gameSerializer.Save(world, saveName);
        else if (Input.GetKeyUp(KeyCode.F9))
            gameSerializer.Load(world, player, mainCamera, saveName);


        //+ Controllers
        activeController.Update();
        sun.lightSystemBehaviour.Update();


        //+ Reset queue
        if (world.chunksToReset.Count > 0)
        {
            // Check if there is more than one chunk to reset, and reset the second in the list if true
            if (world.chunksToReset.Count > 1)
            {
                // Resets the chunk
                world.chunk[world.chunksToReset[1].x, world.chunksToReset[1].y, world.chunksToReset[1].z].BuildChunkVertices(world);
                world.chunk[world.chunksToReset[1].x, world.chunksToReset[1].y, world.chunksToReset[1].z].BuildChunkMesh();

                // Removes the reseted chunk from the list
                world.chunksToReset.Remove(world.chunksToReset[1]);
            }

            // Resets the chunk
            world.chunk[world.chunksToReset[0].x, world.chunksToReset[0].y, world.chunksToReset[0].z].BuildChunkVertices(world);
            world.chunk[world.chunksToReset[0].x, world.chunksToReset[0].y, world.chunksToReset[0].z].BuildChunkMesh();

            // Removes the reseted chunk from the list
            world.chunksToReset.Remove(world.chunksToReset[0]);
        }
    }
}