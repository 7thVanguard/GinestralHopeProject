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
    public float backLeftVertex = SWorld.maxSediment;
    public float backRightVertex = SWorld.maxSediment;
    public float frontLeftVertex = SWorld.maxSediment;
    public float frontRightVertex = SWorld.maxSediment;

    // Transparent faces
    public bool frontTransparent;
    public bool rightTransparent;
    public bool backTransparent;
    public bool leftTransparent;
    public bool topTransparent;
    public bool botTransparent;

    // Game atributes
    public int blastResistance;


    public VoxelGenerator(IntVector3 ID, IntVector3 chunkID, string name)
    {
        hashName = name;

        parentChunkID = chunkID;
        numID = ID;

        SetVoxelProperties(hashName);
    }


    public void BuildVoxelVertices(List<Vector3> Vertices, List<Vector2> UV, List<int> Triangles)
    {
        switch (voxelType)
        {
            case VoxelType.VTERRAIN:
                {
                    if (LVTerrain.IsFaceVisible(parentChunkID, numID) == true)
                        LVTerrain.FaceVertices(parentChunkID, numID, Vertices, UV, Triangles);
                }
                break;
            case VoxelType.VMINE:
                {
                    LVMine.DetectSorroundings(parentChunkID, numID);
                    LVMine.FaceVertices(parentChunkID, numID, Vertices, UV, Triangles);
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


    public void BuildVoxelNormals(List<Vector3> Normals)
    {
        switch (voxelType)
        {
            case VoxelType.VTERRAIN:
                {
                    if (LVTerrain.IsFaceVisible(parentChunkID, numID) == true)
                        LVTerrain.FaceNormals(parentChunkID, numID, Normals);
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


    private void SetVoxelProperties(string hashName)
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
            case "Grass":
                {
                    voxelType = VoxelType.VTERRAIN;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * SWorld.textureSize, 7 * SWorld.textureSize);
                }
                break;
            case "DirtGrass":
                {
                    voxelType = VoxelType.VTERRAIN;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * SWorld.textureSize, 7 * SWorld.textureSize);
                }
                break;
            case "BreakRock":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * SWorld.textureSize, 6 * SWorld.textureSize);
                }
                break;
            case "Rock":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(1 * SWorld.textureSize, 6 * SWorld.textureSize);
                }
                break;
            case "Wood":
                {
                    voxelType = VoxelType.VMINE;
                    voxelState = VoxelState.SOLID;

                    UVStart = new Vector2(0 * SWorld.textureSize, 5 * SWorld.textureSize);
                }
                break;
            default:
                break;
        }
    }
}
