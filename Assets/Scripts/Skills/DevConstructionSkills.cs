using UnityEngine;
using System.Collections;

public class DevConstructionSkills
{
    // Detecting variables
    // Base detections
    public static ChunkGenerator chunk;
    public static VoxelGenerator voxel;

    // Auxiliar
    public static ChunkGenerator detChunk;
    public static VoxelGenerator detVoxel;
    public static Vector2 detVertex;

    // Multi selection tools
    public static bool selected = false;

    // Number of the vertex: 0 - backLeft, 1 - backRight, 2 - frontRight, 3 - frontLeft
    private static int voxelVertex;


    // Math variables
    private static int sedimentExcess;
    private static int sedimentPerClick = 3;

    public void Update(World world)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Remove(world);
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            Place(world);
        else if (Input.GetKeyDown(KeyCode.Mouse2))
            Cancel();
        else
            Detect(world);
    }


    private void Remove(World world)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Remove(world);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Remove(world);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Remove();
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Remove();
    }


    private void Place(World world)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Place(world);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Place(world);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Place(world);
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Place(world);
    }


    private void Cancel()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Cancel();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Cancel();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Cancel();
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Cancel();
    }


    private void Detect(World world)
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Detect(world);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Detect(world);
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Detect(world);
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Detect(world);
    }
}
