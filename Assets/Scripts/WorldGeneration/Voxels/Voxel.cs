using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Voxel
{
    public enum EntityType { TERRAIN, MINE, FLUID, GADGET, ENEMY, AIR }
    public EntityType entityType;

    public enum VoxelState { SOLID, FLUID, GAS }
    public VoxelState voxelState;


    public string ID;
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
            case "Sand Way":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 7 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Little Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 3;
                }
                break;
            case "Large Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 6;
                }
                break;
            case "Medium Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 6;
                }
                break;
            case "Medium Broken Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 2;
                }
                break;
            case "Rock Brick Floor":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(4 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 6;
                }
                break;
            case "Stripped Rock Wall":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(5 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Irregular Smooth Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(6 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 7;
                }
                break;
            case "Amethyst Smooth Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(7 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 4;
                }
                break;
            case "Dark Brown Wood":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 1;
                }
                break;
            case "Three Wood Column Mine":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 5 * world.textureSize);
                }
                break;
            case "Two Wood Column Mine":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 5 * world.textureSize);
                }
                break;
            case "Wood base Large Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 5 * world.textureSize);
                }
                break;
            case "Fire large Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 4 * world.textureSize);
                }
                break;
            case "Fire Rock Brick Floor":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 4 * world.textureSize);
                }
                break;
            case "Fire Irregular Smooth Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 4 * world.textureSize);
                }
                break;
            case "Fire Amethyst Smooth Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 4 * world.textureSize);
                }
                break;
            case "Moss Large Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 3 * world.textureSize);
                }
                break;
            case "Moss Medium Rock":
                {
                    entityType = EntityType.MINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 3 * world.textureSize);
                }
                break;
            default:
                break;
        }
    }
}
