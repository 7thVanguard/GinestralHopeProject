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
        switch (hashName)
        {
            case "Air":
                {
                    type = VoxelType.AIR;
                    state = VoxelState.GAS;

                    frontTransparent = true;
                    rightTransparent = true;
                    backTransparent = true;
                    leftTransparent = true;
                    topTransparent = true;
                    botTransparent = true;
                }
                break;
            case "P1(0, 7)":
                {
                    type = VoxelType.TERRAIN;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(0 * world.textureSize, 7 * world.textureSize);

                    blastResistance = 10;
                }
                break;
            case "P1(0, 6)":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(0 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 9;
                }
                break;
            case "P1(1, 6)":
                {
                    type = VoxelsList.dictionary[hashName].type;
                    state = VoxelsList.dictionary[hashName].state;

                    UVStartTop = VoxelsList.dictionary[hashName].topUVBegin;

                    blastResistance = 12;
                    frontTransparent = VoxelsList.dictionary[hashName].frontTransparent;
                    rightTransparent = VoxelsList.dictionary[hashName].rightTransparent;
                    backTransparent = VoxelsList.dictionary[hashName].backTransparent;
                    leftTransparent = VoxelsList.dictionary[hashName].leftTransparent;
                    topTransparent = VoxelsList.dictionary[hashName].topTransparent;
                    botTransparent = VoxelsList.dictionary[hashName].botTransparent;
                }
                break;
            case "Medium Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(2 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 10;
                }
                break;
            case "Medium Broken Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(3 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Rock Brick Floor":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(4 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 14;
                }
                break;
            case "Stripped Rock Wall":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(5 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 12;
                }
                break;
            case "Irregular Smooth Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(6 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 12;
                }
                break;
            case "Amethyst Smooth Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(7 * world.textureSize, 6 * world.textureSize);

                    blastResistance = 4;
                }
                break;
            case "P1(0, 5)":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(0 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 2;
                }
                break;
            case "Three Wood Column Mine":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(1 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Two Wood Column Mine":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(2 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 5;
                }
                break;
            case "Wood base Large Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(3 * world.textureSize, 5 * world.textureSize);

                    blastResistance = 6;
                }
                break;
            case "Fire large Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(0 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 14;
                }
                break;
            case "Fire Rock Brick Floor":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(1 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 20;
                }
                break;
            case "Fire Irregular Smooth Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(2 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 14;
                }
                break;
            case "Fire Amethyst Smooth Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(3 * world.textureSize, 4 * world.textureSize);

                    blastResistance = 8;
                }
                break;
            case "Moss Large Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(0 * world.textureSize, 3 * world.textureSize);

                    blastResistance = 9;
                }
                break;
            case "Moss Medium Rock":
                {
                    type = VoxelType.ORGANIC;
                    state = VoxelState.SOLID;

                    UVStartTop = new Vector2(1 * world.textureSize, 3 * world.textureSize);

                    blastResistance = 8;
                }
                break;
			case "Brown Trunk Column":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(0 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Brown Trunk Medium Large Rock":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(1 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Brown Trunk Smooth Irregular Rock":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(2 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Smooth Rock":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(3 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Smooth Rock Column":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(4 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Metal Base Smooth Rock":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(5 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Metal Base Brown Trunk Column":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(6 * world.textureSize, 2 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Two Stone Brick Floor":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(0 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Eight Stone Brick Floor":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(1 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "Hexagonal Stone Brick Floor":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(2 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "UL Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(3 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "UR Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(4 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "BL Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(5 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "BR Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(6 * world.textureSize, 1 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "C Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(0 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "L Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(1 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "U Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(2 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "R Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(3 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
			case "B Fire Carpet":
				{
					type = VoxelType.ORGANIC;
					state = VoxelState.SOLID;
					
					UVStartTop = new Vector2(4 * world.textureSize, 0 * world.textureSize);
					
					blastResistance = 8;
				}
				break;
            default:
                break;
        }
    }
}
