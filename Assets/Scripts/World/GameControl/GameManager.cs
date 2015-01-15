using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    // Controllers
    private Dictionary<string, GameController> Controller;

    private GameController activeController;


    // Main control classes
    private Enemy enemy;
    private Interactive interactive;
    private Geometry geometry;
    private Skill skill;


    // Save
    public GameSerializer gameSerializer;
    public string saveName;

    void Awake()
    {
        // Basic variables, activated in PreInit
        VoxelsList.Init();                                                                                  // Initialize Voxels


        //+ Object Init
        Global.world = new World(gameObject);
        Global.player = new Player(Global.world);
        Global.mainCamera = new MainCamera();
        Global.sun = new Sun(Global.player);

        // post initialize
        Global.world.worldObj.GetComponent<HUD>().Init(Global.player);                                      // Initialize HUD
        InventoryManager.Init();                                                                            // Initialize Inventory


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

        aPC = new DeveloperGameController(Global.world, Global.player, Global.mainCamera, Global.sun);
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
        interactive = new Interactive();
        interactive.Init(Global.world, Global.player, Global.mainCamera, interactive);


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
                PassToPlayer();
            }
            else if (Input.GetKey(KeyCode.F2))
            {
                activeController = Controller["GodMode"];
                PassToGod();
            }
            else if (Input.GetKey(KeyCode.F3))
            {
                activeController = Controller["DeveloperMode"];
                PassToDeveloper();
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


    private void PassToPlayer()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), false);

        GameFlow.gameMode = GameFlow.GameMode.PLAYER;
        Global.player.constructionDetection = 300;

        HUD.cubeMarker.SetActive(false);
    }


    private void PassToGod()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), true);

        GameFlow.gameMode = GameFlow.GameMode.GODMODE;
        Global.player.constructionDetection = 300;

        HUD.cubeMarker.SetActive(false);
    }


    private void PassToDeveloper()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("GameObject"), false);

        GameFlow.gameMode = GameFlow.GameMode.DEVELOPER;
        Global.player.constructionDetection = 300;

        if (GameFlow.selectedTool == GameFlow.SelectedTool.VOXEL)
            HUD.cubeMarker.SetActive(true);
        else
            HUD.cubeMarker.SetActive(false);
    }


    private void ChanmgeGameParams()
    {
        Global.mainCamera.ChangeCameraParams();
    }
}