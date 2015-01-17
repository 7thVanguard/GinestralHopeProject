using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum VoxelState { SOLID, FLUID, GAS }
public enum VoxelType { TERRAIN, ORGANIC, CUBIC, FLUID, AIR }

public struct VoxelData
{
    public VoxelState state;
    public VoxelType type;

    public string name;

    public Vector2 topUVBegin;
    public Vector2 rightUVBegin;
    public Vector2 frontUVBegin;
    public Vector2 leftUVBegin;
    public Vector2 backUVBegin;
    public Vector2 botUVBegin;

    public bool topTransparent;
    public bool rightTransparent;
    public bool frontTransparent;
    public bool leftTransparent;
    public bool backTransparent;
    public bool botTransparent;

    public int blastResistance;
    public Texture2D icon;
}


public class VoxelsList
{
    public static Dictionary<string, VoxelData> dictionary = new Dictionary<string, VoxelData>();
    public static VoxelData selectedVoxel;


    public static void Init()
    {
        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.TERRAIN, "(0, 7)",
                                    0, 7, false, 0, 5, false, 0, 5, false,
                                    0, 5, false, 0, 5, false, 0, 5, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(0, 6)",
                                    0, 6, false, 0, 5, false, 0, 5, false,
                                    0, 5, false, 0, 5, false, 0, 5, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.ORGANIC, "(1, 6)",
                                    1, 6, false, 2, 6, false, 2, 6, false,
                                    2, 6, false, 2, 6, false, 0, 4, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.CUBIC, "(0, 5)", 
                                    0, 5, false, 0, 5, false, 0, 5, false, 
                                    0, 5, false, 0, 5, false, 0, 5, false,
                                    10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);
    }


    private static VoxelData InitVoxel(VoxelState state, VoxelType type, string name,
                                        int topX, float topY, bool topTrans, float rightX, float rightY, bool rightTrans,
                                        float frontX, float frontY, bool frontTrans, float leftX, float leftY, bool leftTrans,
                                        float backX, float backY, bool backTrans, float botX, float botY, bool botTrans,
                                        int blastResis)
    {
        VoxelData voxel = new VoxelData();

        voxel.state = state;
        voxel.type = type;

        voxel.name = name;

        voxel.topUVBegin.x = topX * 0.125f;
        voxel.topUVBegin.y = topY * 0.125f;

        voxel.rightUVBegin.x = rightX * 0.125f;
        voxel.rightUVBegin.y = rightY * 0.125f;

        voxel.frontUVBegin.x = frontX * 0.125f;
        voxel.frontUVBegin.y = frontY * 0.125f;

        voxel.leftUVBegin.x = leftX * 0.125f;
        voxel.leftUVBegin.y = leftY * 0.125f;

        voxel.backUVBegin.x = backX * 0.125f;
        voxel.backUVBegin.y = backY * 0.125f;

        voxel.botUVBegin.x = botX * 0.125f;
        voxel.botUVBegin.y = botY * 0.125f;

        voxel.topTransparent = topTrans;
        voxel.rightTransparent = rightTrans;
        voxel.frontTransparent = frontTrans;
        voxel.leftTransparent = leftTrans;
        voxel.backTransparent = backTrans;
        voxel.botTransparent = botTrans;

        voxel.blastResistance = blastResis;

        return voxel;
    }
}
