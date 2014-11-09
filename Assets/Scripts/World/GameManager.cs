using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    // Inspector variables
    public Transform prefabs;
    public Material atlas;
    public Flare sunFlare;


    // Controllers
    private Dictionary<string, GameController> Controllers;

    private GameController activeController;


    // GameObjects
    private World world;
    private GameObject player;
    private GameObject mainCamera;

    private UPlayer uPlayer;
    


    void Awake()
    {
        //+ Object Init
        world = new World(gameObject, prefabs, atlas);
        player = ObjectCreator.PlayerCreation(world);
        mainCamera = ObjectCreator.CameraCreation();
        ObjectCreator.SunCreation(sunFlare);


        //+ Game modes
        Controllers = new Dictionary<string, GameController>();

        GameController aPC;

        aPC = new PlayerCombatGameController(world, player, mainCamera);
        aPC.Start();
        Controllers.Add("PlayerCombatMode", aPC);

        aPC = new PlayerBuildGameController(world, player, mainCamera);
        aPC.Start();
        Controllers.Add("PlayerBuildMode", aPC);

        aPC = new DeveloperCombatGameController(world, player, mainCamera);
        aPC.Start();
        Controllers.Add("DeveloperCombatMode", aPC);

        aPC = new DeveloperBuildGameController(world, player, mainCamera);
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

        // Reset chunks queue
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