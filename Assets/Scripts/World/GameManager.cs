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
    
    //GUI
    public Texture2D background;
    public Font ghFont;
    public Texture2D title;
    public Texture2D pressStart;
    public Texture2D iddleButton;
    public Texture2D pressedButton;
    public Texture2D hoverButton;

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
    public EGameSerializer gameSerializer;
    public string saveName;

    void Awake()
    {
        //+ Object Init
        world = new World(gameObject, prefabs, mineAtlas);
        player = new Player(world);
        mainCamera = new MainCamera();
        sun = new Sun(player, sunFlare);

        // post initialize
        world.worldObj.GetComponent<HUD>().Init(player, mineAtlas, developerAtlas, developerBox);                                                   // Initialize HUD
        world.worldObj.GetComponent<GUISystem>().Init(world, player, background, pressStart, iddleButton, pressedButton, hoverButton, title, ghFont);       // Initialize GUI
        sun.lightSystemBehaviour.Init(player, sun.sunObj, sun.lensFlare);                                                                           // Initialize Light System


        //+ Controllers Init
        Controller = new Dictionary<string, GameController>();


        //+ Physic ignores
        Physics.IgnoreCollision(mainCamera.cameraObj.collider, player.playerObj.GetComponent<CharacterController>());
        Physics.IgnoreCollision(player.playerObj.GetComponent<CharacterController>(), mainCamera.cameraObj.collider);


        //+ Game modes
        GameController aPC;

        aPC = new PlayerGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("PlayerMode", aPC);

        aPC = new GodGameController(world, player, mainCamera);
        aPC.Start();
        Controller.Add("GodMode", aPC);

        aPC = new DeveloperGameController(world, player, mainCamera, sun);
        aPC.Start();
        Controller.Add("DeveloperMode", aPC);

        activeController = Controller["PlayerMode"];


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
        {
            activeController = Controller["PlayerMode"];
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), false);
        }
        else if (Input.GetKey(KeyCode.F2))
        {
            activeController = Controller["GodMode"];
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), true);
        }
        else if (Input.GetKey(KeyCode.F3))
        {
            activeController = Controller["DeveloperMode"];
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), false);
        }

        // Pause
        if (Input.GetKeyUp(KeyCode.P))
            EGameFlow.pause = !EGameFlow.pause;

        // Save relative
        if (Input.GetKeyUp(KeyCode.F5))
            gameSerializer.Save(world, player, saveName);
        else if (Input.GetKeyUp(KeyCode.F9))
            gameSerializer.Load(world, player, saveName);


        //+ Controllers
        if (EGameFlow.gameState == EGameFlow.GameState.GAME)
        {
            activeController.Update();
            sun.lightSystemBehaviour.Update();

            if (Input.GetKeyUp(KeyCode.Escape))
                EGameFlow.gameState = EGameFlow.GameState.MENU;

            if (!Input.GetKey(KeyCode.LeftControl))
                Screen.lockCursor = true;
            else
                Screen.lockCursor = false;
        }
        else
        {
            Screen.lockCursor = false;
        }


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