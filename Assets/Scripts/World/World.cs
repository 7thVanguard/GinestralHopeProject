using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World
{
    // Chunks relative
    public IntVector3 chunkNumber = new IntVector3(1, 1, 1);                    // Initial number of chunks
    public IntVector3 chunkSize = new IntVector3(8, 8, 8);                      // Space occupied by a chunk
    public Chunk[, ,] chunk;                                                    // Chunks declaration
    public List<IntVector3> chunksToReset = new List<IntVector3>();             // Control the chunks we are going to reset

    // GameObjects
    public GameObject worldObj;


    // Prefabs
    public Transform character;
    public Transform geometry;
    public Transform interactives;
    public Transform skills;
    public Transform enemies;
    public Transform effects;


    // Control Variables
    public GameObject geometryController = new GameObject();
    public GameObject interactivesController = new GameObject();
    public GameObject enemiesController = new GameObject();
    public GameObject eventsController = new GameObject();
    public GameObject emitersController = new GameObject();

    public static bool gameLoaded = false;
    public static bool voxelsPrepared = false;
    private bool chunksCreated = false;
    private bool chunksFilled = false;

    private int chunksLoadedPerFrame = 12;
    private int chunksLoadedThisFrame = 0;


    // Materials relative
    public Material atlas;
    public float textureSize = 0.125f;


    // GUI
    public GUISkin GHSkin;


    public World(GameObject world, Transform prefabs, Material atlas, GUISkin GHSkin)
    {
        this.worldObj = world;
        this.GHSkin = GHSkin;
        this.atlas = atlas;

        // Prefabs relative
        character = prefabs.FindChild("Characters");
        geometry = prefabs.FindChild("Geometry");
        interactives = prefabs.FindChild("Interactives");
        skills = prefabs.FindChild("Skills");
        enemies = prefabs.FindChild("Enemies");
        effects = prefabs.FindChild("Effects");

        Init();

        worldObj.AddComponent<HUD>();
    }


    public void Init()
    {
        //+ World setting
        worldObj.name = "World";

        // Set world transforms
        worldObj.transform.position = Vector3.zero;
        worldObj.transform.eulerAngles = Vector3.zero;
        worldObj.transform.localScale = Vector3.one;

        chunk = new Chunk[chunkNumber.x, chunkNumber.y, chunkNumber.z];
        //+ World creation
        for(int cx = 0; cx < chunkNumber.x; cx++)
            for(int cy = 0; cy < chunkNumber.y; cy++)
                for (int cz = 0; cz < chunkNumber.z; cz++)
                    chunk[cx, cy, cz] = new Chunk(new IntVector3(cx, cy, cz), atlas);

            // Instantiates and Fills the chunks.
        for(int cx = 0; cx < chunkNumber.x; cx++)
            for(int cy = 0; cy < chunkNumber.y; cy++)
                for(int cz = 0; cz < chunkNumber.z; cz++)
                {
                    chunk[cx, cy, cz].InstantiateChunk(this);
                    chunk[cx, cy, cz].DefaultChunkFilling(this);    // Default map asigment
                }

            // Builds the vertices of the chunks if they have voxels inside, if not, set them as empty.
        for(int cx = 0; cx < chunkNumber.x; cx++)
            for(int cy = 0; cy < chunkNumber.y; cy++)
                for(int cz = 0; cz < chunkNumber.z; cz++)
                {
                    if (chunk[cx, cy, cz].empty == false)
                        chunk[cx, cy, cz].BuildChunkVertices(this);
                    else
                        chunk[cx, cy, cz].chunkObject.SetActive(false);
                }

            // Vuild the normals and the final mesh
        for(int cx = 0; cx < chunkNumber.x; cx++)
            for(int cy = 0; cy < chunkNumber.y; cy++)
                for(int cz = 0; cz < chunkNumber.z; cz++)
                    if (!chunk[cx, cy, cz].empty)
                    {
                        chunk[cx, cy, cz].BuildChunkNormals(this);
                        chunk[cx, cy, cz].BuildChunkMesh();
                    }


        //+ Controllers
        geometryController.transform.position = Vector3.zero;
        geometryController.transform.eulerAngles = Vector3.zero;
        geometryController.transform.localScale = Vector3.one;
        geometryController.name = "Geometry Controller";

        interactivesController.transform.position = Vector3.zero;
        interactivesController.transform.eulerAngles = Vector3.zero;
        interactivesController.transform.localScale = Vector3.one;
        interactivesController.name = "Interactives Controller";

        enemiesController.transform.position = Vector3.zero;
        enemiesController.transform.eulerAngles = Vector3.zero;
        enemiesController.transform.localScale = Vector3.one;
        enemiesController.name = "Enemies Controller";

        eventsController.transform.position = Vector3.zero;
        eventsController.transform.eulerAngles = Vector3.zero;
        eventsController.transform.localScale = Vector3.one;
        eventsController.name = "Events Controller";

        emitersController.transform.position = Vector3.zero;
        emitersController.transform.eulerAngles = Vector3.zero;
        emitersController.transform.localScale = Vector3.one;
        emitersController.name = "Emitters Controller";
    }
}
