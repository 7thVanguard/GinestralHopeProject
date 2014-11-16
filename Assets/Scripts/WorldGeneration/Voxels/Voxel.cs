using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Voxel : Entity
{
    public enum VoxelState { SOLID, FLUID, GAS }
    public VoxelState voxelState;

    public Vector3 position;

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


    public Voxel(World world, IntVector3 numID, IntVector3 chunkID, string name)
    {
        ID = name;

        parentChunkID = chunkID;
        this.numID = numID;

        SetVoxelProperties(world, ID);
    }


    public void BuildVoxelVertices(World world, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, ref int vertexCount)
    {
        switch (entityType)
        {
            case EntityType.TERRAIN:
                {
                    if (TerrainVoxel.IsFaceVisible(world, parentChunkID, numID) == true)
                        TerrainVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case EntityType.MINE:
                {
                    MineVoxel.DetectSorroundings(world, parentChunkID, numID);
                    MineVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case EntityType.FLUID:
                {

                }
                break;
            default:
                break;
        }
    }


    public void BuildVoxelNormals(World world, List<Vector3> Normals)
    {
        switch (entityType)
        {
            case EntityType.TERRAIN:
                {
                    if (TerrainVoxel.IsFaceVisible(world, parentChunkID, numID) == true)
                        TerrainVoxel.FaceNormals(world, parentChunkID, numID, Normals);
                }
                break;
            case EntityType.MINE:
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
                    entityType = EntityType.AIR;
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
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 7 * world.textureSize);
                }
                break;
            case "LittleRocks":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "OtherRock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "BrokenRock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "RockFloor":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(4 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "RockWall":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(5 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "SmoothRock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(6 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "AmatistRock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(7 * world.textureSize, 6 * world.textureSize);
                }
                break;
            case "Wood":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 5 * world.textureSize);
                }
                break;
            case "WoodLateralColumn":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 5 * world.textureSize);
                }
                break;
            case "WoodCentralColumn":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 5 * world.textureSize);
                }
                break;
            default:
                break;
        }
    }
}
