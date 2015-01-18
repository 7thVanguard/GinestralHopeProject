using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Voxel
{
    public VoxelType type;
    public VoxelState state;


    public string ID;
    public Vector3 position;

    // Identifiers
    public IntVector3 parentChunkID;
    public IntVector3 parentSliceID;
    public IntVector3 numID;

    // Material relative
    public Vector2 UVStartTop;
    public Vector2 UVStartRight;
    public Vector2 UVStartFront;
    public Vector2 UVStartLeft;
    public Vector2 UVStartBack;
    public Vector2 UVStartBot;

    // Intermediate height level (Terrain)
    public float backLeftVertex;
    public float backRightVertex;
    public float frontLeftVertex;
    public float frontRightVertex;

    // Transparent faces
    public bool frontTransparent;
    public bool rightTransparent;
    public bool backTransparent;
    public bool leftTransparent;
    public bool topTransparent;
    public bool botTransparent;

    // Game atributes
    public int blastResistance;


    public Voxel(World world, IntVector3 numID, IntVector3 chunkID, string name)
    {
        ID = name;

        parentChunkID = chunkID;
        this.numID = numID;

        SetVoxelProperties(world, ID);

        position = new Vector3(chunkID.x * world.chunkSize.x + numID.x + 0.5f,
                               chunkID.y * world.chunkSize.y + numID.y + 0.5f,
                               chunkID.z * world.chunkSize.z + numID.z + 0.5f);
    }


    public void BuildVoxelVertices(World world, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, ref int vertexCount)
    {
        switch (type)
        {
            case VoxelType.TERRAIN:
                {
                    TerrainVoxel.DetectSorroundings(world, parentChunkID, numID);
                    TerrainVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case VoxelType.ORGANIC:
                {
                    OrganicVoxel.DetectSorroundings(world, parentChunkID, numID);
                    OrganicVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case VoxelType.CUBIC:
                {
                    CubicVoxel.DetectSorroundings(world, parentChunkID, numID);
                    CubicVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case VoxelType.FLUID:
                {

                }
                break;
            default:
                break;
        }
    }


    public void BuildVoxelNormals(World world, List<Vector3> Normals)
    {
        switch (type)
        {
            case VoxelType.TERRAIN:
                {
                    
                }
                break;
            default:
                break;
        }
    }


    private void SetVoxelProperties(World world, string hashName)
    {
        if (hashName == "Air")
        {
            state = VoxelState.GAS;
            type = VoxelType.AIR;

            frontTransparent = true;
            rightTransparent = true;
            backTransparent = true;
            leftTransparent = true;
            topTransparent = true;
            botTransparent = true;
        }
        else
        {
            type = VoxelsList.dictionary[hashName].type;
            state = VoxelsList.dictionary[hashName].state;

            UVStartTop = VoxelsList.dictionary[hashName].topUVBegin;
            UVStartRight = VoxelsList.dictionary[hashName].rightUVBegin;
            UVStartFront = VoxelsList.dictionary[hashName].frontUVBegin;
            UVStartLeft = VoxelsList.dictionary[hashName].leftUVBegin;
            UVStartBack = VoxelsList.dictionary[hashName].backUVBegin;
            UVStartBot = VoxelsList.dictionary[hashName].botUVBegin;

            blastResistance = 12;
            frontTransparent = VoxelsList.dictionary[hashName].frontTransparent;
            rightTransparent = VoxelsList.dictionary[hashName].rightTransparent;
            backTransparent = VoxelsList.dictionary[hashName].backTransparent;
            leftTransparent = VoxelsList.dictionary[hashName].leftTransparent;
            topTransparent = VoxelsList.dictionary[hashName].topTransparent;
            botTransparent = VoxelsList.dictionary[hashName].botTransparent;
        }
    }
}
