using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VoxelGenerator
{
    public enum VoxelState { SOLID, FLUID, GAS }
    public VoxelState voxelState;
    public enum VoxelType { VTERRAIN, VMINE, VGADGET, VFLUID, AIR }
    public VoxelType voxelType;

    public string hashName;

    // Identifiers
    public IntVector3 parentChunkID;
    public IntVector3 parentSliceID;
    public IntVector3 numID;

    // Material relative
    public Vector2 UVStart;

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


    public VoxelGenerator(World world, IntVector3 ID, IntVector3 chunkID, string name)
    {
        hashName = name;

        parentChunkID = chunkID;
        numID = ID;

        SetVoxelProperties(world, hashName);
    }


    public void BuildVoxelVertices(World world, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, ref int vertexCount)
    {
        switch (voxelType)
        {
            case VoxelType.VTERRAIN:
                {
                    if (LVTerrain.IsFaceVisible(world, parentChunkID, numID) == true)
                        LVTerrain.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case VoxelType.VMINE:
                {
                    LVMine.DetectSorroundings(world, parentChunkID, numID);
                    LVMine.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case VoxelType.VFLUID:
                {

                }
                break;
            default:
                break;
        }
    }


    public void BuildVoxelNormals(World world, List<Vector3> Normals)
    {
        switch (voxelType)
        {
            case VoxelType.VTERRAIN:
                {
                    if (LVTerrain.IsFaceVisible(world, parentChunkID, numID) == true)
                        LVTerrain.FaceNormals(world, parentChunkID, numID, Normals);
                }
                break;
            case VoxelType.VMINE:
                {
                    
                }
                break;
            case VoxelType.VGADGET:
                {

                }
                break;
            default:
                break;
        }
    }


    private void SetVoxelProperties(World world, string hashName)
    {
        switch (hashName)
        {
            case "Air":
                {
                    voxelType = VoxelType.AIR;
                    voxelState = VoxelState.GAS;

                    frontTransparent = true;
                    rightTransparent = true;
                    backTransparent = true;
                    leftTransparent = true;
                    topTransparent = true;
                    botTransparent = true;
                }
                break;
            case "SandWay":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 7 * world.textureSize);
                }
                break;
            case "LittleRocks":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "Rock":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "OtherRock":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "BrokenRock":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "RockFloor":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(4 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "RockWall":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(5 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "SmoothRock":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(6 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "AmatistRock":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(7 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "Wood":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 5 * world.textureSize);
                }
                break;
            case "WoodLateralColumn":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 5 * world.textureSize);
                }
                break;
            case "WoodCentralColumn":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 5 * world.textureSize);
                }
                break;
            default:
                break;
        }
    }
}
