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
    public Texture2D developerAtlas;
    public Flare sunFlare;
    
    //GUI
    public GUISkin GHSkin;

    // End of inspector variables
    // Controllers
    private Dictionary<string, GameController> Controller;

    private GameController activeController;


    // Main control classes
    private Sun sun;

    private Enemy enemy;
    private Interactive gadget;
    private Geometry geometry;
    private Skill skill;
    

    // Save
    public GameSerializer gameSerializer;
    public string saveName;

    void Awake()
    {
        //+ Object Init
        Global.world = new World(gameObject, prefabs, mineAtlas, GHSkin);
        Global.player = new Player(Global.world);
        Global.mainCamera = new MainCamera();
        sun = new Sun(Global.player, sunFlare);

        // post initialize
        Global.world.worldObj.GetComponent<HUD>().Init(Global.player, mineAtlas, developerAtlas);       // Initialize HUD
        sun.lightSystemBehaviour.Init(Global.player, sun.sunObj, sun.lensFlare);                        // Initialize Light System
        InventoryManager.Init();                                                                        // Initialize Inventory


        //+ Controllers Init
        Controller = new Dictionary<string, GameController>();


        //+ Physic ignores
        Physics.IgnoreCollision(Global.mainCamera.cameraObj.collider, Global.player.playerObj.GetComponent<CharacterController>());
        Physics.IgnoreCollision(Global.player.playerObj.GetComponent<CharacterController>(), Global.mainCamera.cameraObj.collider);


        //+ Game modes
        GameController aPC;

        aPC = new PlayerGameController(Global.world, Global.player, Global.mainCamera);
        aPC.Start();
        Controller.Add("PlayerMode", aPC);

        aPC = new GodGameController(Global.world, Global.player, Global.mainCamera);
        aPC.Start();
        Controller.Add("GodMode", aPC);

        aPC = new DeveloperGameController(Global.world, Global.player, Global.mainCamera, sun);
        aPC.Start();
        Controller.Add("DeveloperMode", aPC);

        activeController = Controller["PlayerMode"];

        //+ Enemies Init
        enemy = new Enemy();
        enemy.Init(Global.world, Global.player, Global.mainCamera, enemy);


        //+ Geometries Init
        geometry = new Geometry();
        geometry.Init(Global.world, Global.player, Global.mainCamera);

        //+ Gadgets Init
        gadget = new Interactive();
        gadget.Init(Global.world, Global.player, Global.mainCamera, gadget);


        //+ Skills Init
        skill = new Skill();
        skill.Init(Global.world, Global.player, Global.mainCamera, skill);

        gameSerializer = new GameSerializer();
    }


    void Update()
    {
        if (GameFlow.gameState == GameFlow.GameState.MENU)
        {
            if (Input.GetKey(KeyCode.G))
            {
                GameFlow.runningGame = GameFlow.RunningGame.GINESTRAL_HOPE;
                ChanmgeGameParams();
            }
            else if (Input.GetKey(KeyCode.C))
            {
                GameFlow.runningGame = GameFlow.RunningGame.CLOUDS_SIGHT;
                ChanmgeGameParams();
            }
            else if (Input.GetKey(KeyCode.P))
            {
                GameFlow.runningGame = GameFlow.RunningGame.PLANNED_DREAM;
                ChanmgeGameParams();
            }

            Screen.lockCursor = false;
        }
        else if (GameFlow.gameState == GameFlow.GameState.GAME)
        {
            //+ Global inputs
            // Game mode
            if (Input.GetKey(KeyCode.F1))
            {
                activeController = Controller["PlayerMode"];
                Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), false);

                GameFlow.gameMode = GameFlow.GameMode.PLAYER;
                Global.player.constructionDetection = 5;
            }
            else if (Input.GetKey(KeyCode.F2))
            {
                activeController = Controller["GodMode"];
                Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), true);

                GameFlow.gameMode = GameFlow.GameMode.GODMODE;
                Global.player.constructionDetection = 300;
            }
            else if (Input.GetKey(KeyCode.F3))
            {
                activeController = Controller["DeveloperMode"];
                Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), false);

                GameFlow.gameMode = GameFlow.GameMode.DEVELOPER;
                Global.player.constructionDetection = 300;
            }

            // Pause
            if (Input.GetKeyUp(KeyCode.P))
                GameFlow.pause = !GameFlow.pause;

            // Save relative
            if (Input.GetKeyUp(KeyCode.F5))
                gameSerializer.Save(Global.world, Global.player, saveName);
            else if (Input.GetKeyUp(KeyCode.F9))
                gameSerializer.Load(Global.world, Global.player, saveName);


            //+ Controllers
            activeController.Update();
            sun.lightSystemBehaviour.Update();

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (!GameFlow.onInterface)
                {
                    GameFlow.gameState = GameFlow.GameState.MENU;
                    GameGUI.GHMainMenu.SetActive(true);
                }
            }

            // Cursor control
            if (GameFlow.onInterface || GameFlow.pause)
                Screen.lockCursor = false;
            else
            {
                if (GameFlow.gameMode != GameFlow.GameMode.PLAYER)
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                        Screen.lockCursor = false;
                    else
                    {
                        Screen.lockCursor = true;
                    }
                }
            }
        }


        //+ Reset queue
        if (Global.world.chunksToReset.Count > 0)
        {
            // Check if there is more than one chunk to reset, and reset the second in the list if true
            if (Global.world.chunksToReset.Count > 1)
            {
                // Resets the chunk
                Global.world.chunk[Global.world.chunksToReset[1].x, Global.world.chunksToReset[1].y, Global.world.chunksToReset[1].z].BuildChunkVertices(Global.world);
                Global.world.chunk[Global.world.chunksToReset[1].x, Global.world.chunksToReset[1].y, Global.world.chunksToReset[1].z].BuildChunkMesh();

                // Removes the reseted chunk from the list
                Global.world.chunksToReset.Remove(Global.world.chunksToReset[1]);
            }

            // Resets the chunk
            Global.world.chunk[Global.world.chunksToReset[0].x, Global.world.chunksToReset[0].y, Global.world.chunksToReset[0].z].BuildChunkVertices(Global.world);
            Global.world.chunk[Global.world.chunksToReset[0].x, Global.world.chunksToReset[0].y, Global.world.chunksToReset[0].z].BuildChunkMesh();

            // Removes the reseted chunk from the list
            Global.world.chunksToReset.Remove(Global.world.chunksToReset[0]);
        }
    }


    private void ChanmgeGameParams()
    {
        Global.mainCamera.ChangeCameraParams();
    }
}