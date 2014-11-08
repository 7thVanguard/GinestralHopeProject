using UnityEngine;
using System.Collections;

public class UWorldGenerator : MonoBehaviour 
{
    public Flare sunFlare;
    public Transform prefabs;
    public Material mat;
    public string saveName;


    // Control Variables
    public static bool gameLoaded = false;
    public static bool voxelsPrepared = false;
    private bool chunksCreated = false;
    private bool chunksFilled = false;

    private int chunksLoadedPerFrame = 12;
    private int chunksLoadedThisFrame = 0;

    private int cx = 0, cy = 0, cz = 0;


	void Awake () 
    {
        // World
        SWorld.world = this.gameObject;
        ObjectCreator.WorldSet(SWorld.world);
        ObjectCreator.PlayerCreation();
        ObjectCreator.SunCreation(sunFlare);

        SWorld.chunk = new ChunkGenerator[SWorld.chunkNumber.x, SWorld.chunkNumber.y, SWorld.chunkNumber.z];

        SWorld.saveName = this.saveName;

        // 3D models
        // Enemies
        SWorld.normalSlime = prefabs.FindChild("Normal Slime");

        // Gadgets
        SWorld.woodPieces = prefabs.FindChild("Wood Pieces");
        SWorld.nails = prefabs.FindChild("Nails");
	}
	


	void Update () 
    {        
        // Create the world
        if (!gameLoaded)
        {
            chunksLoadedThisFrame = 0;

            // Creates the chunks.
            if (!chunksCreated)
            {
                while (!chunksCreated && chunksLoadedThisFrame < chunksLoadedPerFrame)
                {
                    SWorld.chunk[cx, cy, cz] = new ChunkGenerator(new IntVector3(cx, cy, cz), mat);

                    chunksCreated = CreationController();
                }
            }
            // Instantiates and Fills the chunks.
            else if (!chunksFilled)
            {
                while (!chunksFilled && chunksLoadedThisFrame < chunksLoadedPerFrame)
                {
                    SWorld.chunk[cx, cy, cz].InstantiateChunk();
                    SWorld.chunk[cx, cy, cz].DefaultChunkFilling();    // Default map asigment

                    chunksFilled = CreationController();
                }
            }
            // Builds the vertices of the chunks if they have voxels inside, if not, set them as empty.
            else if (!voxelsPrepared)
            {
                while (!voxelsPrepared && chunksLoadedThisFrame < chunksLoadedPerFrame)
                {
                    if (SWorld.chunk[cx, cy, cz].empty == false)
                        SWorld.chunk[cx, cy, cz].BuildChunkVertices();
                    else
                        SWorld.chunk[cx, cy, cz].chunkObject.SetActive(false);

                    voxelsPrepared = CreationController();
                }
            }
                // Vuild the normals and the final mesh
            else if (!gameLoaded)
            {
                while (!gameLoaded && chunksLoadedThisFrame < chunksLoadedPerFrame)
                {
                    if (!SWorld.chunk[cx, cy, cz].empty)
                    {
                        SWorld.chunk[cx, cy, cz].BuildChunkNormals();
                        SWorld.chunk[cx, cy, cz].BuildChunkMesh();
                    }

                    gameLoaded = CreationController();
                }
            }
        }


        // Reset chunks queue
        if (SWorld.chunksToReset.Count > 0)
        {
            // Check if there is more than one chunk to reset, and reset the second in the list if true
            if (SWorld.chunksToReset.Count > 1)
            {
                // Resets the chunk
                SWorld.chunk[SWorld.chunksToReset[1].x, SWorld.chunksToReset[1].y, SWorld.chunksToReset[1].z].BuildChunkVertices();
                SWorld.chunk[SWorld.chunksToReset[1].x, SWorld.chunksToReset[1].y, SWorld.chunksToReset[1].z].BuildChunkMesh();

                // Removes the reseted chunk from the list
                SWorld.chunksToReset.Remove(SWorld.chunksToReset[1]);
            }

            // Resets the chunk
            SWorld.chunk[SWorld.chunksToReset[0].x, SWorld.chunksToReset[0].y, SWorld.chunksToReset[0].z].BuildChunkVertices();
            SWorld.chunk[SWorld.chunksToReset[0].x, SWorld.chunksToReset[0].y, SWorld.chunksToReset[0].z].BuildChunkMesh();

            // Removes the reseted chunk from the list
            SWorld.chunksToReset.Remove(SWorld.chunksToReset[0]);
        }
	}


    public static void TotalReset()
    {
        voxelsPrepared = false;
        gameLoaded = false;
    }


    // Acts as a tridimensional "for" keeping the counters for the next update
    private bool CreationController()
    {
        chunksLoadedThisFrame++;
        cz++;
        if (cz == SWorld.chunkNumber.z)
        {
            cz = 0;
            cy++;
            if (cy == SWorld.chunkNumber.y)
            {
                cy = 0;
                cx++;
                if (cx == SWorld.chunkNumber.x)
                {
                    cx = 0;
                    return true;
                }
            }
        }
        return false;
    }
}
