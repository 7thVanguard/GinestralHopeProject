using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    // Inspector variables
    // Prefabs
    public Transform prefabs;

    // Materials
    public Material mineAtlas;

    // Textures
    // Developer
    public Texture2D developerAtlas;
    public Texture2D developerBox;

    public Flare sunFlare;
    public string saveName;


    // Controllers
    private Dictionary<string, GameController> Controller;

    private GameController activeController;


    // Main control classes
    private World world;
    private Player player;
    private MainCamera mainCamera;
    private Sun sun;

    private Enemy enemy;
    private Gadget gadget;
    private Skill skill;
    

    // Save
    EGameSerializer gameSerializer;


    void Awake()
    {
        //+ Object Init
        world = new World(gameObject, prefabs, mineAtlas);
        player = new Player();
        mainCamera = new MainCamera();
        sun = new Sun(player, sunFlare);

        // post initialize
        world.worldObj.GetComponent<HUD>().Init(player, developerAtlas, developerBox);      // Initialize HUD
        sun.lightSystemBehaviour.Init(player, sun.sunObj, sun.lensFlare);                   // Initialize Light System



        //+ Controllers Init
        Controller = new Dictionary<string, GameController>();



        //+ Game modes
        GameController aPC;

        aPC = new PlayerGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("PlayerMode", aPC);

        aPC = new GodGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("GodMode", aPC);

        aPC = new DeveloperGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("DeveloperMode", aPC);

        activeController = Controller["DeveloperMode"];


        //+ Enemies Init
        enemy = new Enemy();
        enemy.Init(world, player, mainCamera, enemy);


        //+ Gadgets Init
        gadget = new Gadget();
        gadget.Init(world, player, mainCamera, gadget);


        //+ Skills Init
        skill = new Skill();
        skill.Init(world, player, mainCamera, skill);

        gameSerializer = new EGameSerializer();
    }


    void Update()
    {
        //+ Global inputs
        // Game mode
        if (Input.GetKey(KeyCode.F1))
            activeController = Controller["PlayerMode"];
        else if (Input.GetKey(KeyCode.F2))
            activeController = Controller["GodMode"];
        else if (Input.GetKey(KeyCode.F3))
            activeController = Controller["DeveloperMode"];

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