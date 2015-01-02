using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Voxel
{
    public enum EntityType { TERRAIN, ORGANIC, CUBIC, FLUID, GADGET, ENEMY, AIR }
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

        position = new Vector3(chunkID.x * world.chunkSize.x + numID.x + 0.5f,
                               chunkID.y * world.chunkSize.y + numID.y + 0.5f,
                               chunkID.z * world.chunkSize.z + numID.z + 0.5f);
    }


    public void BuildVoxelVertices(World world, List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles, ref int vertexCount)
    {
        switch (entityType)
        {
            case EntityType.TERRAIN:
                {
                    TerrainVoxel.DetectSorroundings(world, parentChunkID, numID);
                    TerrainVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case EntityType.ORGANIC:
                {
                    OrganicVoxel.DetectSorroundings(world, parentChunkID, numID);
                    OrganicVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
                }
                break;
            case EntityType.CUBIC:
                {
                    CubicVoxel.DetectSorroundings(world, parentChunkID, numID);
                    CubicVoxel.FaceVertices(world, parentChunkID, numID, Vertices, UV, Triangles, ref vertexCount);
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
                    entityType = EntityType.TERRAIN;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 7 * world.textureSize);

                    blastResistance = 10;
                }
                break;
            case "Little Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 9;
                }
                break;
            case "Large Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 12;
                }
                break;
            case "Medium Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 10;
                }
                break;
            case "Medium Broken Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Rock Brick Floor":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(4 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 14;
                }
                break;
            case "Stripped Rock Wall":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(5 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 12;
                }
                break;
            case "Irregular Smooth Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(6 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 12;
                }
                break;
            case "Amethyst Smooth Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(7 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 4;
                }
                break;
            case "Dark Brown Wood":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 2;
                }
                break;
            case "Three Wood Column Mine":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Two Wood Column Mine":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Wood base Large Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 6;
                }
                break;
            case "Fire large Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 14;
                }
                break;
            case "Fire Rock Brick Floor":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 20;
                }
                break;
            case "Fire Irregular Smooth Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(2 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 14;
                }
                break;
            case "Fire Amethyst Smooth Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(3 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 8;
                }
                break;
            case "Moss Large Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * world.textureSize, 3 * world.textureSize);

                    blastResistance = 9;
                }
                break;
            case "Moss Medium Rock":
                {
                    entityType = EntityType.ORGANIC;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * world.textureSize, 3 * world.textureSize);

                    blastResistance = 8;
                }
                break;
			case "Brown Trunk Column":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(0 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Brown Trunk Medium Large Rock":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(1 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Brown Trunk Smooth Irregular Rock":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(2 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Smooth Rock":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(3 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Smooth Rock Column":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(4 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Metal Base Smooth Rock":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(5 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Metal Base Brown Trunk Column":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(6 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Two Stone Brick Floor":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(0 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Eight Stone Brick Floor":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(1 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Hexagonal Stone Brick Floor":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(2 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "UL Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(3 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "UR Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(4 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "BL Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(5 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "BR Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(6 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "C Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(0 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "L Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(1 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "U Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(2 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "R Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(3 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "B Fire Carpet":
				{
					entityType = EntityType.ORGANIC;
					voxelState = VoxelState.SOLID;
					
					UVStart = new Vector2(4 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
            default:
                break;
        }
    }
}
