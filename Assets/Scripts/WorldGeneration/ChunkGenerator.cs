using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkGenerator
{
    public GameObject chunkObject;
    public VoxelGenerator[, ,] voxel;        // Part of a chunk with no defined size

    // Identifiers
    public IntVector3 numID;        // World identifier of every chunk. (Name of the chunk) and relative position

    // Atlas material
    private Material mat;           

    // Lists
    private List<Vector3> Vertices;
    private List<Vector2> UV;
    private List<int> Triangles;
    private List<Vector3> Normals;

    //Attribute List
    public bool empty;
    public bool nullify;

    // Limits
    public bool frontLimit;
    public bool rightLimit;
    public bool backLimit;
    public bool leftLimit;
    public bool topLimit;
    public bool botLimit;

        
    public ChunkGenerator(IntVector3 chunkNumber, Material material)
    {
        // Set the identifiers
        numID = chunkNumber;

        // Keep the material in the chunk information
        mat = material;
    }


    public void InstantiateChunk()
    {
        // Create the chunk as a GameObject
        chunkObject = new GameObject();
        chunkObject.name = "Chunk (" + numID.x + ", " + numID.y + ", " + numID.z + ")";
        chunkObject.tag = ("Chunk");

        // Set chunk transforms
        chunkObject.transform.position = Vector3.zero;
        chunkObject.transform.eulerAngles = Vector3.zero;
        chunkObject.transform.localScale = Vector3.one;

        chunkObject.transform.parent = SWorld.world.transform;

        // Chunk components
        chunkObject.AddComponent<MeshRenderer>();
        chunkObject.renderer.material = mat;

        // Initiates lists
        Vertices = new List<Vector3>();
        UV = new List<Vector2>();
        Triangles = new List<int>();
        Normals = new List<Vector3>();
    }


    public void DefaultChunkFilling()       // Called only for default plain map
    {
        voxel = new VoxelGenerator[SWorld.chunkSize.x, SWorld.chunkSize.y, SWorld.chunkSize.z];

        // Default chunk filling, half grass, half air
        for (int x = 0; x < SWorld.chunkSize.x; x++)
            for (int y = 0; y < SWorld.chunkSize.y; y++)
                for (int z = 0; z < SWorld.chunkSize.z; z++)
                {
                    if((numID.x == 0 && x == 0) || (numID.y == 0 && y == 0) || (numID.z == 0 && z == 0) || 
                                 ((numID.x == SWorld.chunkNumber.x - 1 && x == SWorld.chunkSize.x - 1)) ||
                                 ((numID.z == SWorld.chunkNumber.z - 1 && z == SWorld.chunkSize.z - 1)))
                        voxel[x, y, z] = new VoxelGenerator(new IntVector3(x, y, z), numID, "Rock");
                    else
                        voxel[x, y, z] = new VoxelGenerator(new IntVector3(x, y, z), numID, "Air");
                }
    }


    public void BuildChunkVertices()
    {
        // If chunk is empty, we fill it with air and set it to active
        if (empty == true)
        {
            for (int x = 0; x < SWorld.chunkSize.x; x ++)
                for (int y = 0; y < SWorld.chunkSize.y; y++)
                    for (int z = 0; z < SWorld.chunkSize.z; z ++)
                        voxel[x, y, z] = new VoxelGenerator(new IntVector3(x, y, z), numID, "Air");

            empty = false;
            chunkObject.SetActive(true);
        }

        // Resets de vertices counter for building the chunk again again
        SWorld.vertexCount = 0;

        // Connect chunk with it's slices
        // vpx and vpz = voxel package x and z
        for (int x = 0; x < SWorld.chunkSize.x; x++)
            for (int z = 0; z < SWorld.chunkSize.z; z++)
                for (int y = 0; y < SWorld.chunkSize.y; y++)
                    voxel[x, y, z].BuildVoxelVertices(Vertices, UV, Triangles);
    }


    public void BuildChunkNormals()
    {
        // Connect chunk with it's slices
        for (int x = 0; x < SWorld.chunkSize.x; x ++)
            for (int z = 0; z < SWorld.chunkSize.z; z ++)
                for (int y = 0; y < SWorld.chunkSize.y; y++)
                    voxel[x, y, z].BuildVoxelNormals(Normals);
    }


    public void BuildChunkMesh()
    {
        // Create arrays with the information of the lists
        Vector3[] verticesVector = new Vector3[Vertices.Count];
        Vector2[] UVVecor = new Vector2[UV.Count];
        int[] trianglesVector = new int[Triangles.Count];
        Vector3[] normalsVector = new Vector3[Normals.Count];


        // Assign vertices
        for (int i = 0; i < Vertices.Count; i++)    
        {
            verticesVector[i] = Vertices[i];
            UVVecor[i] = UV[i];
            //normalsVector[i] = Normals[i];
        }
        // Assign normals
        for (int i = 0; i < Triangles.Count; i++)
            trianglesVector[i] = Triangles[i];
        

        // Clear the lists
        Vertices.Clear();
        UV.Clear();
        Triangles.Clear();
        Normals.Clear();

        // Make sure there is a MeshFilter
        if (chunkObject.GetComponent<MeshFilter>() == null)
            chunkObject.AddComponent<MeshFilter>();
        else
            chunkObject.GetComponent<MeshFilter>().mesh.Clear();

        // Assign the information in the arrays to the mesh
        chunkObject.GetComponent<MeshFilter>().mesh.vertices = verticesVector;
        chunkObject.GetComponent<MeshFilter>().mesh.uv = UVVecor;
        chunkObject.GetComponent<MeshFilter>().mesh.triangles = trianglesVector;
        //chunkObject.GetComponent<MeshFilter>().mesh.normals = normalsVector;

        chunkObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        // Make sure there is a MeshCollider
        if (chunkObject.GetComponent<MeshCollider>() != null)
            Transform.Destroy(chunkObject.GetComponent<MeshCollider>());

        chunkObject.AddComponent<MeshCollider>();
    }
}
