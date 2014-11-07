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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Remove();
        else if (Input.GetKeyDown(KeyCode.Mouse1))
            Place();
        else if (Input.GetKeyDown(KeyCode.Mouse2))
            Cancel();
        else
            Detect();
    }


    private void Remove()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Remove();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Remove();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Remove();
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Remove();
    }


    private void Place()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Place();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Place();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Place();
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Place();
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


    private void Detect()
    {
        if (EGameFlow.selectedTool == EGameFlow.SelectedTool.TERRAIN)
            LTerrainVoxelTool.Detect();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.MINE)
            LMineVoxelTool.Detect();
        else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.GADGET)
            LGadgetsTool.Detect();
		else if (EGameFlow.selectedTool == EGameFlow.SelectedTool.ENEMY)
			LEnemyTool.Detect();
    }
}
