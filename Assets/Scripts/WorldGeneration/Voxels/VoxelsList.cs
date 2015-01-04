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
    public string atlasName;

    public float topUVBeginX;
    public float topUVBeginY;

    public float rightUVBeginX;
    public float rightUVBeginY;

    public float frontUVBeginX;
    public float frontUVBeginY;

    public float leftUVBeginX;
    public float leftUVBeginY;

    public float backUVBeginX;
    public float backUVBeginY;

    public float botUVBeginX;
    public float botUVBeginY;

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
        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.TERRAIN, "Air", "Faeri", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                  true, true, true, true, true, true,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);

        selectedVoxel = InitVoxel(VoxelState.SOLID, VoxelType.TERRAIN, "Large Rock", "Faeri", 0, 7, 0, 7, 0, 7, 0, 7, 0, 7, 0, 7,
                                  false, false, false, false, false, false,
                                  10);
        dictionary.Add(selectedVoxel.name, selectedVoxel);
    }


    private static VoxelData InitVoxel(VoxelState state, VoxelType type, string name, string atlasName, int topX, float topY, float rightX, float rightY, 
                                  float frontX, float frontY, float leftX, float leftY, float backX, float backY, float botX, float botY, 
                                  bool topTrans, bool rightTrans, bool frontTrans, bool leftTrans, bool backTrans, bool botTrans,
                                  int blastResis)
    {
        VoxelData voxel = new VoxelData();

        voxel.state = VoxelState.SOLID;
        voxel.type = VoxelType.TERRAIN;

        voxel.name = name;
        voxel.atlasName = atlasName;

        voxel.topUVBeginX = topX * 0.125f;
        voxel.topUVBeginY = topY * 0.125f;

        voxel.rightUVBeginX = rightX;
        voxel.rightUVBeginY = rightY;

        voxel.frontUVBeginX = frontX;
        voxel.frontUVBeginY = frontY;

        voxel.leftUVBeginX = leftX;
        voxel.leftUVBeginY = leftY;

        voxel.backUVBeginX = backX;
        voxel.backUVBeginY = backY;

        voxel.botUVBeginX = botX;
        voxel.botUVBeginY = botY;

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
